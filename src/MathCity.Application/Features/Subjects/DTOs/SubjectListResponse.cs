using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCity.Application.Features.Subjects.DTOs;

public class SubjectListResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public string Icon { get; set; } = string.Empty;

    public string Description {  get; set; } = string.Empty;

    public bool IsPublished { get; set; }

    public int DisplayOrder { get; set; }

    public string Color { get; set; } = string.Empty;

    // agrigate counts for chapters, topics, lessons, lesson resources, and practice questions
    public int ChapterCount { get; set; }
    public int TopicCount { get; set; }
    public int LessonCount { get; set; }
    public int LessonResourceCount { get; set; }
    public int PracticeQuestionCount { get; set; }
}