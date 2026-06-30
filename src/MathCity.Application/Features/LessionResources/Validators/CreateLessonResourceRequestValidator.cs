using FluentValidation;
using MathCity.Application.Features.LessonResources.DTOs;

namespace MathCity.Application.Features.LessonResources.Validators;

public class CreateLessonResourceRequestValidator
    : AbstractValidator<CreateLessonResourceRequest>
{
    public CreateLessonResourceRequestValidator()
    {
        RuleFor(x => x.LessonId)
            .NotEmpty();

        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Url)
            .NotEmpty()
            .MaximumLength(1000);

        RuleFor(x => x.DisplayOrder)
            .GreaterThanOrEqualTo(0);
    }
}