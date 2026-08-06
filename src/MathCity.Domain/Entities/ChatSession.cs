using MathCity.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCity.Domain.Entities;

public class ChatSession : BaseEntity
{
    public string SessionId { get; set; } = string.Empty;

    public Guid? UserId { get; set; }

    public DateTime LastAccessedAt { get; set; }

    public DateTime ExpiresAt { get; set; }

    public ICollection<ChatMessage> Messages { get; set; }
        = new List<ChatMessage>();
}