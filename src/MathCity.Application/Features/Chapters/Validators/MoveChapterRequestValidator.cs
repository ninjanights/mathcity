using FluentValidation;
using MathCity.Application.Features.Subjects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCity.Application.Features.Chapters.Validators;

public class MoveChapterRequestValidator
    : AbstractValidator<MoveSubjectRequest>
{
    public MoveChapterRequestValidator()
    {
        RuleFor(x => x.Direction)
     .IsInEnum();
    }
}
