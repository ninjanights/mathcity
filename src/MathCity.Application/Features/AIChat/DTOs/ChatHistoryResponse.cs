using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCity.Application.Features.AIChat.DTOs;

public class ChatHistoryResponse
{
    public List<ChatMessageDto> Messages { get; set; } = new();

    public bool HasMore { get; set; }

    public Guid? NextCursor { get; set; }
}
