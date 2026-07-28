using MathCity.Application.Features.LessonVectorEmbeddings.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCity.Application.Features.LessonVectorEmbeddings.DTOs;

public class SemanticSearchRequest
{
    public string Query { get; set; } = string.Empty;

    public int TopK { get; set; } = 5;
    public SearchContext Context { get; set; } = SearchContext.Global;


    public Guid? LessonId { get; set; }

        public Guid? TopicId { get; set; }

        public Guid? ChapterId { get; set; }
    }



