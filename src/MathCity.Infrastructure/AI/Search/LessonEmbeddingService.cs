using MathCity.Application.Features.LessonVectorEmbeddings.DTOs;
using MathCity.Application.Features.LessonVectorEmbeddings.Interfaces;
using MathCity.Domain.Entities;
using MathCity.Domain.Enums;
using MathCity.Infrastructure.AI.Embeddings;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

using MathCity.Infrastructure.Settings;
using Microsoft.Extensions.Options;

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
    private readonly AISettings _settings;


    public LessonEmbeddingService(
        ApplicationDbContext context,
        IEmbeddingGenerator embeddingGenerator,
        IOptions<AISettings> options)
    {
        _context = context;
        _embeddingGenerator = embeddingGenerator;
        _settings = options.Value;
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


        var existingEmbeddings = await _context.LessonVectorEmbeddings
     .Where(x => x.LessonId == lesson.Id)
     .ToListAsync();


        var transaction = await _context.Database.BeginTransactionAsync();
        try  {
            _context.LessonVectorEmbeddings.RemoveRange(existingEmbeddings);

            var chunks = CreateChunks(lesson);
            var embeddings = new List<LessonVectorEmbedding>();
            var chunkIndex = 0;

            foreach (var chunk in chunks)
            {
                var vector = await _embeddingGenerator.GenerateAsync(chunk.Content);
                var dimension = vector.ToArray().Length;
                if (dimension != 768)
                {
                    throw new Exception(
                        $"Invalid embedding dimension. Expected 768, got {dimension}."
                    );
                }

                Console.WriteLine(
        $"Saving chunk index: {chunkIndex} | {chunk.Title}"
    );

                embeddings.Add(new LessonVectorEmbedding
                {
                    LessonId = lesson.Id,

                    SourceId = chunk.SourceId,

                    Model = _settings.Model,

                    Dimensions = dimension,

                    ChunkType = chunk.Type,

                    ChunkIndex = chunkIndex++,

                    Title = chunk.Title,

                    Content = chunk.Content,

                    Embedding = vector,

                    TokenCount = 0
                });
                Console.WriteLine(
                    $"✓ {chunk.Type} | {chunk.Title} | {dimension} dimensions");
            }
            lesson.EmbeddingsGeneratedAt = DateTime.UtcNow;
            _context.LessonVectorEmbeddings.AddRange(embeddings);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return new LessonEmbeddingResponse
            {
                LessonId = lesson.Id,
                ChunksCreated = embeddings.Count,
                GeneratedAt = lesson.EmbeddingsGeneratedAt.Value
            };
        }
        catch
        {       
            await transaction.RollbackAsync();
            throw;
        }
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

        Content:
        {lesson.Content}
        """,

            Type = EmbeddingChunkType.Summary,
        });

        if (lesson.LessonTags.Any())


            chunks.Add(new EmbeddingChunk
            {
                Title = $"{lesson.Title} Tags",

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

    Tags:
    {string.Join(", ", lesson.LessonTags.Select(x => x.Tag.Name))}
    """,

                Type = EmbeddingChunkType.Tag
            });



        foreach (var resource in lesson.Resources)
        {
            chunks.Add(new EmbeddingChunk
            {
                Title = resource.Title,

                Content =
                $"""
        Resource:
        {resource.Title}

        Description:
        {resource.Description}

        File:
        {resource.FileName}
        """,

                Type = EmbeddingChunkType.Resource,

                SourceId = resource.Id
            });
        }


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

        if (lesson.LessonTags.Any())
        {
            chunks.Add(new EmbeddingChunk
            {
                Content =
                "Tags: " +
                string.Join(", ",
                    lesson.LessonTags.Select(x => x.Tag.Name)
                ),

                Type = EmbeddingChunkType.Tag
            });
        }


        return chunks;
    }
}