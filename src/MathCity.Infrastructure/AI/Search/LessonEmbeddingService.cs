using MathCity.Application.Features.LessonVectorEmbeddings.DTOs;
using MathCity.Application.Features.LessonVectorEmbeddings.Interfaces;
using MathCity.Domain.Entities;
using MathCity.Domain.Enums;
using MathCity.Infrastructure.AI.Embeddings;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCity.Infrastructure.AI.Search;
public class LessonEmbeddingService : ILessonEmbeddingService
{

    private readonly ApplicationDbContext _context;
    private readonly IEmbeddingGenerator _embeddingGenerator;


    public LessonEmbeddingService(
        ApplicationDbContext context,
        IEmbeddingGenerator embeddingGenerator)
    {
        _context = context;
        _embeddingGenerator = embeddingGenerator;
    }

    public async Task<LessonEmbeddingResponse> GenerateAsync(Guid lessonId)
    {
        var lesson = await _context.Lessons
            .Include(x => x.Topic)
                .ThenInclude(x => x.Chapter)
                    .ThenInclude(x => x.Subject)
            .Include(x => x.PracticeQuestions)
            .Include(x => x.Resources)
            .Include(x => x.LessonTags)
                .ThenInclude(x => x.Tag)
            .FirstOrDefaultAsync(x => x.Id == lessonId);

        if (lesson == null)
        {
            throw new Exception("Lesson not found.");
        }

        var chunks = CreateChunks(lesson);

        return new LessonEmbeddingResponse
        {
            LessonId = lesson.Id,
            ChunksCreated = chunks.Count,
            GeneratedAt = DateTime.UtcNow
        };
    }

    public async Task<IReadOnlyList<SemanticSearchResult>> SearchAsync(
        SemanticSearchRequest request)
    {
        throw new NotImplementedException();
    }


    // chunk builder
    private List<EmbeddingChunk> CreateChunks(
    Lesson lesson)
    {
        var chunks = new List<EmbeddingChunk>();


        chunks.Add(new EmbeddingChunk
        {
            Title = lesson.Title + " Summary",

            Content =
            $"""
        Subject:
        {lesson.Topic.Chapter.Subject.Name}

        Chapter:
        {lesson.Topic.Chapter.Title}

        Topic:
        {lesson.Topic.Title}

        Lesson:
        {lesson.Title}

        Summary:
        {lesson.Summary}
        """,

            Type = EmbeddingChunkType.Summary
        });



        chunks.Add(new EmbeddingChunk
        {
            Title = lesson.Title,

            Content = lesson.Content,

            Type = EmbeddingChunkType.Lesson
        });



        foreach (var question in lesson.PracticeQuestions)
        {
            chunks.Add(new EmbeddingChunk
            {
                Title = "Practice Question",

                Content =
                $"""
            Question:
            {question.Question}

            Options:
            A. {question.OptionA}
            B. {question.OptionB}
            C. {question.OptionC}
            D. {question.OptionD}

            Explanation:
            {question.Explanation}
            """,

                Type = EmbeddingChunkType.PracticeQuestion,

                SourceId = question.Id
            });
        }


        return chunks;
    }
}