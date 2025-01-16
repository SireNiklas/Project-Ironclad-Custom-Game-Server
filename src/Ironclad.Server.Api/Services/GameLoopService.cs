using Ironclad.Server.Core.Game;

namespace Ironclad.Server.Api.Services;

public class GameLoopService : BackgroundService
{
    private readonly ILogger<GameLoopService> _logger;
    
    public GameLoopService(ILogger<GameLoopService> logger)
    {
        logger = _logger;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            GameLoop.Start();
        }
        finally
        {
            GameLoop.Stop();
        }
        
        await Task.Delay(Timeout.Infinite, stoppingToken);
    }
}