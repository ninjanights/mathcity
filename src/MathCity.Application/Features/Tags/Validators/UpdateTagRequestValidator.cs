using FluentValidation;
using MathCity.Application.Features.Tags.DTOs;

namespace MathCity.Application.Features.Tags.Validators;

public class UpdateTagRequestValidator
    : AbstractValidator<UpdateTagRequest>
{
    public UpdateTagRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);
    }
}