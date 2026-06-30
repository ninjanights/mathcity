using FluentValidation;
using MathCity.Application.Features.Progress.DTOs;

namespace MathCity.Application.Features.Progress.Validators;

public class UpdateProgressRequestValidator
    : AbstractValidator<UpdateProgressRequest>
{
    public UpdateProgressRequestValidator()
    {
        RuleFor(x => x.ProgressPercentage)
            .InclusiveBetween(0, 100);
    }
}