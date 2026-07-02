using MathCity.Application.Features.PracticeQuestions.DTOs;

namespace MathCity.Application.Features.PracticeQuestions.Interfaces;

public interface IPracticeQuestionService
{
    Task<PracticeQuestionResponse> CreateAsync(CreatePracticeQuestionRequest request);

    Task<IReadOnlyList<PracticeQuestionListResponse>> GetAllAsync();

    Task<PracticeQuestionResponse> GetByIdAsync(Guid id);

    Task<IReadOnlyList<PracticeQuestionListResponse>> GetByLessonAsync(Guid lessonId);

    Task<StudentPracticeQuestionResponse> GetByIdForStudentAsync(Guid id);

    Task<IReadOnlyList<StudentPracticeQuestionResponse>> GetByLessonForStudentAsync(Guid lessonId);

    Task<PracticeQuestionResponse> UpdateAsync(
        Guid id,
        UpdatePracticeQuestionRequest request);

    Task DeleteAsync(Guid id);

   Task<PracticeQuestionSubmissionResponse> SubmitAsync(
    Guid? userId,
    SubmitPracticeQuestionsRequest request);
}