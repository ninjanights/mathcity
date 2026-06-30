using FluentValidation;
using MathCity.Application.Features.Topics.DTOs;

namespace MathCity.Application.Features.Topics.Validators;

public class UpdateTopicRequestValidator
    : AbstractValidator<UpdateTopicRequest>
{
    public UpdateTopicRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.DisplayOrder)
            .GreaterThanOrEqualTo(0);
    }
}