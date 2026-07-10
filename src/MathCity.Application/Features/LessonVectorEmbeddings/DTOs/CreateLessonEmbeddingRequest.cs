using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCity.Application.Features.LessonVectorEmbeddings.DTOs;
public class CreateLessonEmbeddingRequest
{
    public Guid LessonId { get; set; }
}