using MathCity.Application.Features.AIChat.DTOs;
using MathCity.Application.Features.AIChat.Interfaces;
using MathCity.Application.Features.LessonVectorEmbeddings.DTOs;
using MathCity.Application.Features.LessonVectorEmbeddings.Interfaces;
using MathCity.Domain.Entities;
using MathCity.Domain.Enums;
using MathCity.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCity.Infrastructure.Services;

public class ChatService : IChatService
{
    private readonly IChatSessionService _chatSessionService;
    private readonly ILessonEmbeddingService _embeddingService;
    private readonly IAIChatService _aiChatService;
    private readonly ApplicationDbContext _context;

    public ChatService(
        IChatSessionService chatSessionService,
        ILessonEmbeddingService embeddingService,
        IAIChatService aiChatService,
        ApplicationDbContext context)
    {
        _chatSessionService = chatSessionService;
        _embeddingService = embeddingService;
        _aiChatService = aiChatService;
        _context = context;
    }

    public async Task<ChatResponse> ChatAsync(ChatRequest request)
    {
        var sessionId = await _chatSessionService.GetOrCreateSessionIdAsync();

        await _chatSessionService.TouchSessionAsync();

        var chatSessionId =
            await _chatSessionService.GetSessionDatabaseIdAsync(sessionId);

        // search for relevant lessons based on the request context
        var results = await _embeddingService.SearchAsync(
    new SemanticSearchRequest
    {
        Query = request.Question,
        Context = request.Context,
        LessonId = request.LessonId,
        TopicId = request.TopicId,
        ChapterId = request.ChapterId,
        TopK = request.TopK
    });



        

        var context = string.Join("\n\n",
    results.Select(x => x.Content));

        var answer = await _aiChatService.GenerateAnswerAsync(
    request.Question,
    context);

        var userMessage = new ChatMessage
        {
            ChatSessionId = chatSessionId,

            Role = ChatRole.User,

            Message = request.Question,

            Context = request.Context,

            LessonId = request.LessonId,

            TopicId = request.TopicId,

            ChapterId = request.ChapterId
        };

        _context.ChatMessages.Add(userMessage);




        var assistantMessage = new ChatMessage
        {
            ChatSessionId = chatSessionId,

            Role = ChatRole.Assistant,

            Message = answer,

            Context = request.Context,

            LessonId = request.LessonId,

            TopicId = request.TopicId,

            ChapterId = request.ChapterId
        };

        _context.ChatMessages.Add(assistantMessage);

        await _context.SaveChangesAsync();

        return new ChatResponse
        {
            SessionId = sessionId,

            Answer = answer,

            Sources = results
        };
    }
}