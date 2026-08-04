using MathCity.Application.Features.AIChat.DTOs;
using MathCity.Application.Features.AIChat.Interfaces;
using MathCity.Application.Features.LessonVectorEmbeddings.DTOs;
using MathCity.Application.Features.LessonVectorEmbeddings.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCity.Infrastructure.AI.Orchestrator;

public class ChatOrchestrator : IChatOrchestrator
{
    private readonly ILessonEmbeddingService _embeddingService;
    private readonly IAIChatService _chatService;

    public ChatOrchestrator(
        ILessonEmbeddingService embeddingService,
        IAIChatService chatService)
    {
        _embeddingService = embeddingService;
        _chatService = chatService;





    }

    public async Task<ChatResponse>ChatAsync(ChatRequest request,
        CancellationToken cancellationToken = default)
    {

        // Search
        var results =
   await _embeddingService.SearchAsync(
       new SemanticSearchRequest
       {
           Query = request.Question,

           Context = request.Context,

           LessonId = request.LessonId,

           TopicId = request.TopicId,

           ChapterId = request.ChapterId,

           TopK = request.TopK
       });

        // Build context
        var context = BuildContext(results);

        // Gemini (later)
        var answer = await _chatService.GenerateAnswerAsync(
            request.Question,
            context,
            cancellationToken);

        return new ChatResponse
        {
            Answer = answer,
            Sources = results.ToList()
        };
    }


    private static string BuildContext(
        IReadOnlyList<SemanticSearchResult> results)
    {
       var builder = new StringBuilder();
        builder.AppendLine(
     "The following information was retrieved from the Niharika knowledge base.");
        builder.AppendLine();

        foreach (var result in results)
        {
            builder.AppendLine(new string('=', 80));

            builder.AppendLine($"Lesson: {result.LessonTitle}");
            builder.AppendLine($"Chunk Type: {result.ChunkType}");
            builder.AppendLine($"Chunk Title: {result.ChunkTitle}");

            builder.AppendLine();

            builder.AppendLine(result.Content);

            builder.AppendLine();
        }

        return builder.ToString();






















    }






}
