using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathCity.Domain.Common;

namespace MathCity.Domain.Entities;

public class Topic : BaseEntity
{
    public Guid ChapterId { get; set; }

    public Chapter Chapter { get; set; } = null!;

    public string Title { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }

    public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}

