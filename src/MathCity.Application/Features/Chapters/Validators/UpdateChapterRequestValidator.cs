using FluentValidation;
using MathCity.Application.Features.Chapters.DTOs;

namespace MathCity.Application.Features.Chapters.Validators;

public class UpdateChapterRequestValidator
    : AbstractValidator<UpdateChapterRequest>
{
    public UpdateChapterRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .MaximumLength(500);

        RuleFor(x => x.DisplayOrder)
            .GreaterThanOrEqualTo(0);
    }
}