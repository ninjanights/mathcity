using FluentValidation;
using MathCity.Application.Features.Lessons.DTOs;

namespace MathCity.Application.Features.Lessons.Validators;

public class CreateLessonRequestValidator
    : AbstractValidator<CreateLessonRequest>
{
    public CreateLessonRequestValidator()
    {
        RuleFor(x => x.TopicId)
            .NotEmpty();

        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Summary)
            .MaximumLength(1000);

        RuleFor(x => x.MarkdownContent)
            .NotEmpty();

        RuleFor(x => x.ReadingTimeMinutes)
            .GreaterThan(0);
    }
}