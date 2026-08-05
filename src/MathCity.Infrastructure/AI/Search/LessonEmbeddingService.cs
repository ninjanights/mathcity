using MathCity.Application.Features.LessonVectorEmbeddings.DTOs;
using MathCity.Application.Features.LessonVectorEmbeddings.Enums;
using MathCity.Application.Features.LessonVectorEmbeddings.Interfaces;
using MathCity.Domain.Entities;
using MathCity.Domain.Enums;
using MathCity.Infrastructure.AI.Embeddings;
using MathCity.Infrastructure.Persistence.Context;
using MathCity.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pgvector.EntityFrameworkCore;
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

                if (dimension != _settings.Dimension)
                {
                    throw new Exception(
                        $"Invalid embedding dimension. Expected {_settings.Dimension}, got {dimension}."
                    );
                }

                Console.WriteLine($"Subject : {lesson.Topic.Chapter.Subject.Name}");
                Console.WriteLine($"Chapter : {lesson.Topic.Chapter.Title}");
                Console.WriteLine($"Topic   : {lesson.Topic.Title}");
                Console.WriteLine($"Lesson  : {lesson.Title}");

                Console.WriteLine(
        $"Saving chunk index: {chunkIndex} | {chunk.Title}"
    );

                embeddings.Add(new LessonVectorEmbedding
                {
                    LessonId = lesson.Id,

                    SourceId = chunk.SourceId,

                    Model = _settings.JinaModel,

                    Dimensions = dimension,

                    ChunkType = chunk.Type,

                    ChunkIndex = chunkIndex++,

                    Title = chunk.Title,

                    Content = chunk.Content,

                    Embedding = vector,

                    TokenCount = 0,
                    SubjectId = lesson.Topic.Chapter.Subject.Id,
                    Tags = lesson.LessonTags
        .Select(x => x.Tag.Name)
        .ToArray(),
                    ChapterId = lesson.Topic.Chapter.Id,

                    TopicId = lesson.Topic.Id,

                    LessonTitle = lesson.Title,

                    SubjectName = lesson.Topic.Chapter.Subject.Name,

                    ChapterName = lesson.Topic.Chapter.Title,

                    TopicName = lesson.Topic.Title,
                });
                Console.WriteLine(
                    $"✓ {chunk.Type} | {chunk.Title} | {dimension} dimensions");
            }

            lesson.IsEmbedded = true;
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

        var queryVector = await _embeddingGenerator.GenerateAsync(request.Query);

        var query = _context.LessonVectorEmbeddings.AsQueryable();
        switch (request.Context)
        {
            case SearchContext.Lesson:
                if (request.LessonId.HasValue)
                    query = query.Where(x => x.LessonId == request.LessonId.Value);
                break;

            case SearchContext.Topic:
                if (request.TopicId.HasValue)
                    query = query.Where(x => x.Lesson.TopicId == request.TopicId.Value);
                break;

            case SearchContext.Chapter:
                if (request.ChapterId.HasValue)
                    query = query.Where(x => x.Lesson.Topic.ChapterId == request.ChapterId.Value);
                break;

            case SearchContext.Global:
            default:
                break;
        }



        var results = await query
            .OrderBy(x => x.Embedding.CosineDistance(queryVector))
            .Take(request.TopK)
            .Select(x => new SemanticSearchResult
            {
                LessonId = x.LessonId,
                SourceId = x.SourceId,

                LessonTitle = x.Lesson.Title,

                ChunkTitle = x.Title,

                Content = x.Content,

                ChunkType = x.ChunkType,

                ChunkIndex = x.ChunkIndex,

                Score = 
                1 - x.Embedding.CosineDistance(queryVector)


            }).ToListAsync();

        return results;

    }


    // chunk builder
    private List<EmbeddingChunk> CreateChunks(
    Lesson lesson)
    {
        var chunks = new List<EmbeddingChunk>();

        
        chunks.Add(new EmbeddingChunk
        {
            Title = lesson.Title + "Summary",

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

                // Learning resource such as article,
                // PDF, YouTube video, etc.

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

Resource:
{resource.Title}

Description:
{resource.Description}
""",

                Type = EmbeddingChunkType.Resource,

                SourceId = resource.Id
            });
        }


        // Main lesson content.
        // Include metadata so this chunk can be understood
        // without relying on database joins.

        chunks.Add(new EmbeddingChunk
        {
            Title = lesson.Title,

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

    Content:
    {lesson.Content}
    """,

            Type = EmbeddingChunkType.Lesson
        });



        foreach (var question in lesson.PracticeQuestions)
        {
            chunks.Add(new EmbeddingChunk
            {
                Title = "Practice Question",

                // Practice question used during semantic search.

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

            // Solution / explanation
            chunks.Add(new EmbeddingChunk
            {
                Title = "Practice Question Solution",

                // Stores the complete solution for retrieval.

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

Question:
{question.Question}

Correct Answer:
{question.CorrectAnswer}

Explanation:
{question.Explanation}
""",

                Type = EmbeddingChunkType.SolutionExplanation,

                SourceId = question.Id
            });





        }

     


        return chunks;
    }
}