using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathCity.Domain.Common;

namespace MathCity.Domain.Entities;

public class Chapter : BaseEntity
{
    public Guid SubjectId { get; set; }

    public Subject Subject { get; set; } = null!;

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }

    public ICollection<Topic> Topics { get; set; } = new List<Topic>();

}

