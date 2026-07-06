using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MathCity.Application.Features.Subjects.DTOs;

namespace MathCity.Application.Features.Subjects.Validators;

public class MoveSubjectRequestValidator
    : AbstractValidator<MoveSubjectRequest>
{
    public MoveSubjectRequestValidator()
    {
        RuleFor(x => x.Position)
            .GreaterThan(0);
    }
}
