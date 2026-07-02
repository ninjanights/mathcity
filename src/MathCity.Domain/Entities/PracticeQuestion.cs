using MathCity.Domain.Common;
using MathCity.Domain.Entities;
using MathCity.Domain.Enums;
public class PracticeQuestion : BaseEntity
{
    public Guid LessonId { get; set; }

    public Lesson Lesson { get; set; } = null!;

    public string Question { get; set; } = string.Empty;

    public string OptionA { get; set; } = string.Empty;

    public string OptionB { get; set; } = string.Empty;

    public string OptionC { get; set; } = string.Empty;

    public string OptionD { get; set; } = string.Empty;

    public string CorrectAnswer { get; set; } = string.Empty;

    public string Explanation { get; set; } = string.Empty;

    public DifficultyLevel Difficulty { get; set; }

    public int DisplayOrder { get; set; }
}