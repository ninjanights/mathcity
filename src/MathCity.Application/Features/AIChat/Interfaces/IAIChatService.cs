using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCity.Application.Features.AIChat.Interfaces;
public interface IAIChatService
{
    Task<string> GenerateAnswerAsync(
        string question,
        string context,
        CancellationToken cancellationToken = default);
}
