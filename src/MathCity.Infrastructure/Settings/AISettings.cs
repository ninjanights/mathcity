using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCity.Infrastructure.Settings;
public class AISettings
{
    public const string SectionName = "AI";
    public string Provider { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string BaseUrl { get; set; } = "http://localhost:11434";

    public int Dimention { get; set; } = 768;
}