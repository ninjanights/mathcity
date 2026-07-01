using FluentValidation;
using MathCity.Application.Features.LessonTags.DTOs;

namespace MathCity.Application.Features.LessonTags.Validators;

public class CreateLessonTagRequestValidator
    : AbstractValidator<CreateLessonTagRequest>
{
    public CreateLessonTagRequestValidator()
    {
        RuleFor(x => x.TagId)
            .NotEmpty();
    }
}