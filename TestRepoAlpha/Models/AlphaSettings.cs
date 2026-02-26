namespace Nimbus.TestRepoAlpha.Models;

/// <summary>
/// Application settings for the Alpha service.
/// </summary>
public class AlphaSettings
{
    public string ServiceName { get; set; } = "AlphaService";
    public string Environment { get; set; } = "Development";
    public int Port { get; set; } = 5000;
    public bool EnableSwagger { get; set; } = true;
}
