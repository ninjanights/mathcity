using MathCity.Domain.Common;
using MathCity.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MathCity.Domain.Entities;


public class Lesson : BaseEntity
{
    public Guid TopicId { get; set; }

    public Topic Topic { get; set; } = null!;

    public string Title { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public string Summary { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public DifficultyLevel Difficulty { get; set; }

    public int ReadingTimeMinutes { get; set; }

    public bool IsPublished { get; set; } = true;

    public int DisplayOrder { get; set; }

    public string ThumbnailUrl { get; set; } = string.Empty;

    public DateTime? EmbeddingsGeneratedAt { get; set; }

    public ICollection<LessonResource> Resources { get; set; } = new List<LessonResource>();

    public ICollection<PracticeQuestion> PracticeQuestions { get; set; } = new List<PracticeQuestion>();
    public ICollection<Bookmark> Bookmarks { get; set; }
    = new List<Bookmark>();

    public ICollection<LessonTag> LessonTags { get; set; }
    = new List<LessonTag>();

    public ICollection<LessonVectorEmbedding> VectorEmbeddings
    = new List<LessonVectorEmbedding>();

}

