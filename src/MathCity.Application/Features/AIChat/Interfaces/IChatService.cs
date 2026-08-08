using MathCity.Application.Features.AIChat.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCity.Application.Features.AIChat.Interfaces;

public interface IChatService
{
    Task<ChatResponse> ChatAsync(ChatRequest request );

    Task<ChatHistoryResponse> GetHistoryAsync(
    Guid? beforeMessageId,
    int take = 10);
}