using FluentValidation;
using MathCity.Application.Features.Subjects.DTOs;

namespace MathCity.Application.Features.Subjects.Validators;

public class CreateSubjectRequestValidator
    : AbstractValidator<CreateSubjectRequest>
{
    public CreateSubjectRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .MaximumLength(500);

        RuleFor(x => x.Icon)
            .MaximumLength(100);

        RuleFor(x => x.Color)
            .NotEmpty()
            .Matches("^#([A-Fa-f0-9]{6})$")
            .WithMessage("Color must be a valid hex color.");

        RuleFor(x => x.DisplayOrder)
            .GreaterThanOrEqualTo(0);
    }
}