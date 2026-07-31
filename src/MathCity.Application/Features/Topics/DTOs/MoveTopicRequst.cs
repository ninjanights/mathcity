using MathCity.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCity.Application.Features.Topics.DTOs;

public class MoveTopicRequest
{
    public MoveDirection Direction { get; set; }
}