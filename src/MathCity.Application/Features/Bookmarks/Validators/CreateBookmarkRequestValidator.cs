using FluentValidation;
using MathCity.Application.Features.Bookmarks.DTOs;

namespace MathCity.Application.Features.Bookmarks.Validators;

public class CreateBookmarkRequestValidator
    : AbstractValidator<CreateBookmarkRequest>
{
    public CreateBookmarkRequestValidator()
    {
        RuleFor(x => x.LessonId)
            .NotEmpty();
    }
}