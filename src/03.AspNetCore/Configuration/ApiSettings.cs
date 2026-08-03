namespace AspNetCoreSamples.Configuration;

/// <summary>
/// Interview topic: Options pattern — strongly-typed configuration.
/// </summary>
public class ApiSettings
{
    public const string SectionName = "ApiSettings";
    public string ApplicationName { get; set; } = "DotNet Interview Samples";
    public int MaxPageSize { get; set; } = 100;
    public bool EnableDetailedErrors { get; set; }
}
