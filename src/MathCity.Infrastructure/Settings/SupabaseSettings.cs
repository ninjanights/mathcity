namespace MathCity.Infrastructure.Settings;

public class SupabaseSettings
{
    public const string SectionName = "Supabase";

    public string ProjectUrl { get; set; } = string.Empty;

    public string ServiceRoleKey { get; set; } = string.Empty;

    public string BucketName { get; set; } = string.Empty;
}