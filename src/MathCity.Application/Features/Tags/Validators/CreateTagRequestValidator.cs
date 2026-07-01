using FluentValidation;
using MathCity.Application.Features.Tags.DTOs;

namespace MathCity.Application.Features.Tags.Validators;

public class CreateTagRequestValidator
    : AbstractValidator<CreateTagRequest>
{
    public CreateTagRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);
    }
}