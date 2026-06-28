using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathCity.Domain.Common;

namespace MathCity.Domain.Entities;

public class Subject : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Icon { get; set; } = string.Empty;

    public string Color { get; set; } = "#2563EB";

    public int DisplayOrder { get; set; }

    public bool IsPublished { get; set; } = true;

    public ICollection<Chapter> Chapters { get; set; } = new List<Chapter>();
}


