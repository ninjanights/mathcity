using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathCity.Domain.Common;
namespace MathCity.Domain.Entities;

public class PracticeQuestion : BaseEntity
{
    public Guid LessonId { get; set; }

    public Lesson Lesson { get; set; } = null!;
}