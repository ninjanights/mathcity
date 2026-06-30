using FluentValidation;
using MathCity.Application.Features.Progress.DTOs;

namespace MathCity.Application.Features.Progress.Validators;

public class CreateProgressRequestValidator
    : AbstractValidator<CreateProgressRequest>
{
    public CreateProgressRequestValidator()
    {
       

        RuleFor(x => x.LessonId)
            .NotEmpty();

        RuleFor(x => x.ProgressPercentage)
            .InclusiveBetween(0, 100);
    }
}