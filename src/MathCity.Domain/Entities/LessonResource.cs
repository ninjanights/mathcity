using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathCity.Domain.Common;
using MathCity.Domain.Enums;

namespace MathCity.Domain.Entities;

public class LessonResource : BaseEntity
{
    public Guid LessonId { get; set; }

    public Lesson Lesson { get; set; } = null!;

    public string Title { get; set; } = string.Empty;

    public string FileName { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string FilePath { get; set; } = string.Empty;

    public string FileUrl { get; set; } = string.Empty;

    public long FileSize { get; set; }

    public string ContentType { get; set; } = string.Empty;

    public ResourceType Type { get; set; }

    public int DisplayOrder { get; set; }
}