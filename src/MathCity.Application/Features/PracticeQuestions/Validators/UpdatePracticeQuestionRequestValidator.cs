using FluentValidation;
using MathCity.Application.Features.PracticeQuestions.DTOs;

namespace MathCity.Application.Features.PracticeQuestions.Validators;

public class UpdatePracticeQuestionRequestValidator
    : AbstractValidator<UpdatePracticeQuestionRequest>
{
    public UpdatePracticeQuestionRequestValidator()
    {
        RuleFor(x => x.Question)
            .NotEmpty()
            .MaximumLength(1000);

        RuleFor(x => x.OptionA).NotEmpty();
        RuleFor(x => x.OptionB).NotEmpty();
        RuleFor(x => x.OptionC).NotEmpty();
        RuleFor(x => x.OptionD).NotEmpty();

        RuleFor(x => x.CorrectAnswer)
            .NotEmpty()
            .Must(x => new[] { "A", "B", "C", "D" }.Contains(x.ToUpper()))
            .WithMessage("Correct answer must be A, B, C or D.");

        RuleFor(x => x.DisplayOrder)
            .GreaterThanOrEqualTo(0);
    }
}