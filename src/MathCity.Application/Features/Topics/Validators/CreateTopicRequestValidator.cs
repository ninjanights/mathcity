using FluentValidation;
using MathCity.Application.Features.Topics.DTOs;

namespace MathCity.Application.Features.Topics.Validators;

public class CreateTopicRequestValidator
    : AbstractValidator<CreateTopicRequest>
{
    public CreateTopicRequestValidator()
    {
        RuleFor(x => x.ChapterId)
            .NotEmpty()
            .WithMessage("Chapter is required.");

        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.DisplayOrder)
            .GreaterThanOrEqualTo(0);
    }
}