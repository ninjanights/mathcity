using MathCity.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCity.Application.Features.Lessons.DTOs;

public class MoveLessonRequest
{
    public MoveDirection Direction { get; set; }
}