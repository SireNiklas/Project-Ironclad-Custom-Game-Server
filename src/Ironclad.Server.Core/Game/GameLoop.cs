using Ironclad.Server.Core.Models;
using Ironclad.Server.Shared.Enums;

namespace Ironclad.Server.Core.Game;

public static class GameLoop
{
    private static CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
    private static Task _gameLoopTask;
    
    public static void Start()
    {
        _gameLoopTask = Run(_cancellationTokenSource.Token);
    }

    public static async Task Run(CancellationToken cancellationToken)
    {
        try
        {
            GameState.InitializeGame();
            while (!cancellationToken.IsCancellationRequested && !GameState.IsGameOver)
            {
                // proccess Game
                // Console.WriteLine("Game Running...");
                
                // Handle Game Loop (Phase handling here!)

                switch (GameState.CurrentPhase)
                {
                    case Phase.Upkeep:
                        HandleUpKeepPhase();
                        break;
                    case Phase.Main:
                        HandleMainPhase();
                        break;
                    case Phase.Combat:
                        HandleCombatPhase();
                        break;
                }
                
                await Task.Delay(100, cancellationToken);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    private static void HandleUpKeepPhase()
    {
        Console.WriteLine("Upkeep Phase");
        GameState.CurrentPhase = Phase.Main;
    }

    private static void HandleMainPhase()
    {
        //Console.WriteLine("Main Phase");
        // Play Card (Type check, placement)
    }

    private static void HandleCombatPhase()
    {
        Console.WriteLine("Combat Phase");
    }
    
    public static void Stop()
    {
        
    }
}