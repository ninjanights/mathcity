namespace MathCity.Application.Features.Progress.DTOs;

public class UpdateProgressRequest
{
    public int ProgressPercentage { get; set; }

    public bool IsCompleted { get; set; }
}