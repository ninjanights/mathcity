using MathCity.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCity.Application.Features.PracticeQuestions.DTOs;


public class PracticeQuestionQuery
{
    public string? LessonSlug { get; set; }

    public string? Search { get; set; }

    public DifficultyLevel? Difficulty { get; set; }

    public int Page { get; set; } = 1;

    public int PageSize { get; set; } = 5;
}