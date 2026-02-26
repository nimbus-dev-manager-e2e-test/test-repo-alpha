using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Nimbus.TestRepoGamma.Services;

namespace Nimbus.TestRepoAlpha.Services;

/// <summary>
/// Background service that performs periodic health checks.
/// </summary>
public class AlphaHostedService : BackgroundService
{
    private readonly ILogger<AlphaHostedService> _logger;
    private readonly GammaService _gammaService;

    public AlphaHostedService(ILogger<AlphaHostedService> logger, GammaService gammaService)
    {
        _logger = logger;
        _gammaService = gammaService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Health check at {Time}", DateTimeOffset.Now);
            _gammaService.ValidateInput("heartbeat");
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}
