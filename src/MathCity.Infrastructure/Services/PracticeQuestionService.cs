using MathCity.Application.Common.Exceptions;
using MathCity.Application.Features.PracticeQuestions.DTOs;
using MathCity.Application.Features.PracticeQuestions.Interfaces;
using MathCity.Application.Features.Progress.Interfaces;
using MathCity.Domain.Entities;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MathCity.Infrastructure.Services;

public class PracticeQuestionService : IPracticeQuestionService
{
    private readonly ApplicationDbContext _context;
    private readonly IProgressService _progressService;

    public PracticeQuestionService(
    ApplicationDbContext context,
    IProgressService progressService)
    {
        _context = context;
        _progressService = progressService;
    }

    public async Task<PracticeQuestionResponse> CreateAsync(CreatePracticeQuestionRequest request)
    {
        var lessonExists = await _context.Lessons
            .AnyAsync(x => x.Id == request.LessonId);

        if (!lessonExists)
            throw new NotFoundException("Lesson not found.");

        await MoveDisplayOrderAsync(
    request.LessonId,
    request.DisplayOrder);

        var question = new PracticeQuestion
        {
            LessonId = request.LessonId,
            Question = request.Question,
            OptionA = request.OptionA,
            OptionB = request.OptionB,
            OptionC = request.OptionC,
            OptionD = request.OptionD,
            CorrectAnswer = request.CorrectAnswer,
            Explanation = request.Explanation,
            Difficulty = request.Difficulty,
            DisplayOrder = request.DisplayOrder
        };

        _context.PracticeQuestions.Add(question);

        await _context.SaveChangesAsync();

        return MapToResponse(question);
    }

    public async Task<StudentPracticeQuestionResponse> GetByIdForStudentAsync(Guid id)
    {
        var question = await _context.PracticeQuestions
            .FirstOrDefaultAsync(x => x.Id == id);

        if (question == null)
            throw new NotFoundException("Practice question not found.");

        return new StudentPracticeQuestionResponse
        {
            Id = question.Id,
            LessonId = question.LessonId,
            Question = question.Question,
            OptionA = question.OptionA,
            OptionB = question.OptionB,
            OptionC = question.OptionC,
            OptionD = question.OptionD,
            Difficulty = question.Difficulty,
            DisplayOrder = question.DisplayOrder
        };
    }

    public async Task<IReadOnlyList<PracticeQuestionListResponse>> GetAllAsync()
    {
        return await _context.PracticeQuestions
            .OrderBy(x => x.DisplayOrder)
            .Select(x => new PracticeQuestionListResponse
            {
                Id = x.Id,
                Question = x.Question,
                Difficulty = x.Difficulty,
                DisplayOrder = x.DisplayOrder
            })
            .ToListAsync();
    }

    public async Task<IReadOnlyList<PracticeQuestionListResponse>> GetByLessonAsync(Guid lessonId)
    {
        return await _context.PracticeQuestions
            .Where(x => x.LessonId == lessonId)
            .OrderBy(x => x.DisplayOrder)
            .Select(x => new PracticeQuestionListResponse
            {
                Id = x.Id,
                Question = x.Question,
                Difficulty = x.Difficulty,
                DisplayOrder = x.DisplayOrder
            })
            .ToListAsync();
    }

    public async Task<IReadOnlyList<StudentPracticeQuestionResponse>> GetByLessonForStudentAsync(Guid lessonId)
    {
        return await _context.PracticeQuestions
            .Where(x => x.LessonId == lessonId)
            .OrderBy(x => x.DisplayOrder)
            .Select(x => new StudentPracticeQuestionResponse
            {
                Id = x.Id,
                LessonId = x.LessonId,
                Question = x.Question,
                OptionA = x.OptionA,
                OptionB = x.OptionB,
                OptionC = x.OptionC,
                OptionD = x.OptionD,
                Difficulty = x.Difficulty,
                DisplayOrder = x.DisplayOrder
            })
            .ToListAsync();
    }

    public async Task<PracticeQuestionResponse> GetByIdAsync(Guid id)
    {
        var question = await _context.PracticeQuestions
            .FirstOrDefaultAsync(x => x.Id == id);

        if (question == null)
            throw new NotFoundException("Practice question not found.");

        return MapToResponse(question);
    }

    public async Task<PracticeQuestionResponse> UpdateAsync(
        Guid id,
        UpdatePracticeQuestionRequest request)
    {



        var question = await _context.PracticeQuestions
            .FirstOrDefaultAsync(x => x.Id == id);

        if (question == null)
            throw new NotFoundException("Practice question not found.");

        if (question.DisplayOrder != request.DisplayOrder)
        {
            await MoveDisplayOrderAsync(
                question.LessonId,
                request.DisplayOrder,
                question.Id);
        }


        question.Question = request.Question;
        question.OptionA = request.OptionA;
        question.OptionB = request.OptionB;
        question.OptionC = request.OptionC;
        question.OptionD = request.OptionD;
        question.CorrectAnswer = request.CorrectAnswer;
        question.Explanation = request.Explanation;
        question.Difficulty = request.Difficulty;
        question.DisplayOrder = request.DisplayOrder;

        await _context.SaveChangesAsync();

        return MapToResponse(question);
    }

    public async Task MoveAsync(
    Guid id,
    MovePracticeQuestionRequest request)
    {
        var question = await _context.PracticeQuestions
            .FirstOrDefaultAsync(x => x.Id == id);

        if (question == null)
            throw new NotFoundException("Practice question not found.");

        await MoveDisplayOrderAsync(
            question.LessonId,
            request.Position,
            question.Id);
    }

    public async Task DeleteAsync(Guid id)
    {
        var question = await _context.PracticeQuestions
            .FirstOrDefaultAsync(x => x.Id == id);

        if (question == null)
            throw new NotFoundException("Practice question not found.");

        _context.PracticeQuestions.Remove(question);

        await _context.SaveChangesAsync();

        var questions = await _context.PracticeQuestions
            .Where(x => x.LessonId == question.LessonId)
            .OrderBy(x => x.DisplayOrder)
            .ToListAsync();

        for (int i = 0; i < questions.Count; i++)
        {
            questions[i].DisplayOrder = i + 1;
        }

        await _context.SaveChangesAsync();
    }

    private async Task MoveDisplayOrderAsync(
    Guid lessonId,
    int newPosition,
    Guid? questionId = null)
    {
        var questions = await _context.PracticeQuestions
            .Where(x => x.LessonId == lessonId)
            .OrderBy(x => x.DisplayOrder)
            .ToListAsync();

        PracticeQuestion? moving = null;

        if (questionId.HasValue)
        {
            moving = questions.First(x => x.Id == questionId.Value);
            questions.Remove(moving);
        }

        newPosition = Math.Clamp(newPosition, 1, questions.Count + 1);

        if (moving != null)
        {
            questions.Insert(newPosition - 1, moving);
        }

        for (int i = 0; i < questions.Count; i++)
        {
            questions[i].DisplayOrder = i + 1000;
        }

        await _context.SaveChangesAsync();

        for (int i = 0; i < questions.Count; i++)
        {
            questions[i].DisplayOrder = i + 1;
        }

        await _context.SaveChangesAsync();
    }

    public async Task<PracticeQuestionSubmissionResponse> SubmitAsync(
       Guid? userId,
       SubmitPracticeQuestionsRequest request)
    {   var questions = await _context.PracticeQuestions
            .Where(x => x.LessonId == request.LessonId)
            .OrderBy(x => x.DisplayOrder)
            .ToListAsync();

        if (!questions.Any())
            throw new NotFoundException("No practice questions found for this lesson.");

        // Validate submission: ensure all questions are answered
        if (request?.Answers == null || request.Answers.Count != questions.Count)
            throw new ValidationException(
                "Please answer all questions before submitting.");

        // Ensure there are no duplicate answers for the same question
        if (request.Answers
            .GroupBy(x => x.QuestionId)
            .Any(g => g.Count() > 1))
        {
            throw new ValidationException(
                "Duplicate answers detected.");
        }

        var results = new List<QuestionResultResponse>();

        var correctAnswers = 0;

        foreach (var answer in request.Answers)
        {
            var question = questions.FirstOrDefault(x => x.Id == answer.QuestionId);

            if (question == null)
                continue;

            var isCorrect =
               question.CorrectAnswer == answer.SelectedAnswer;

            if (isCorrect)
                correctAnswers++;

            results.Add(new QuestionResultResponse
            {
                QuestionId = question.Id,
                SelectedAnswer = answer.SelectedAnswer,
                CorrectAnswer = question.CorrectAnswer,
                IsCorrect = isCorrect,
                Explanation = question.Explanation
            });
        }

        var totalQuestions = questions.Count;

        var scorePercentage = totalQuestions == 0
            ? 0
            : (correctAnswers * 100) / totalQuestions;

        var passed = scorePercentage >= 70;

        // Save progress only for logged-in users
        if (userId.HasValue)
        {
            if (passed)
            {
                await _progressService.CompleteLessonAsync(
                    userId.Value,
                    request.LessonId);
            }
            else
            {
                await _progressService.StartLessonAsync(
                    userId.Value,
                    request.LessonId);
            }
        }

        return new PracticeQuestionSubmissionResponse
        {
            LessonId = request.LessonId,
            TotalQuestions = totalQuestions,
            ScorePercentage = scorePercentage,
            Passed = passed,
            Results = results
        };
    }

    private static PracticeQuestionResponse MapToResponse(PracticeQuestion question)
    {
        return new PracticeQuestionResponse
        {
            Id = question.Id,
            LessonId = question.LessonId,
            Question = question.Question,
            OptionA = question.OptionA,
            OptionB = question.OptionB,
            OptionC = question.OptionC,
            OptionD = question.OptionD,
            CorrectAnswer = question.CorrectAnswer,
            Explanation = question.Explanation,
            Difficulty = question.Difficulty,
            DisplayOrder = question.DisplayOrder
        };
    }
}