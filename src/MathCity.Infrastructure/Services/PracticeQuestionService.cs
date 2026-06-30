using MathCity.Application.Common.Exceptions;
using MathCity.Application.Features.PracticeQuestions.DTOs;
using MathCity.Application.Features.PracticeQuestions.Interfaces;
using MathCity.Domain.Entities;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MathCity.Infrastructure.Services;

public class PracticeQuestionService : IPracticeQuestionService
{
    private readonly ApplicationDbContext _context;

    public PracticeQuestionService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PracticeQuestionResponse> CreateAsync(CreatePracticeQuestionRequest request)
    {
        var lessonExists = await _context.Lessons
            .AnyAsync(x => x.Id == request.LessonId);

        if (!lessonExists)
            throw new NotFoundException("Lesson not found.");

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
            DisplayOrder = request.DisplayOrder
        };

        _context.PracticeQuestions.Add(question);

        await _context.SaveChangesAsync();

        return MapToResponse(question);
    }

    public async Task<IReadOnlyList<PracticeQuestionListResponse>> GetAllAsync()
    {
        return await _context.PracticeQuestions
            .OrderBy(x => x.DisplayOrder)
            .Select(x => new PracticeQuestionListResponse
            {
                Id = x.Id,
                Question = x.Question,
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

        question.Question = request.Question;
        question.OptionA = request.OptionA;
        question.OptionB = request.OptionB;
        question.OptionC = request.OptionC;
        question.OptionD = request.OptionD;
        question.CorrectAnswer = request.CorrectAnswer;
        question.Explanation = request.Explanation;
        question.DisplayOrder = request.DisplayOrder;

        await _context.SaveChangesAsync();

        return MapToResponse(question);
    }

    public async Task DeleteAsync(Guid id)
    {
        var question = await _context.PracticeQuestions
            .FirstOrDefaultAsync(x => x.Id == id);

        if (question == null)
            throw new NotFoundException("Practice question not found.");

        _context.PracticeQuestions.Remove(question);

        await _context.SaveChangesAsync();
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
            DisplayOrder = question.DisplayOrder
        };
    }
}