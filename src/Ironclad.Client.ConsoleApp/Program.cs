using Ironclad.Client.Core.Game;
using Ironclad.Client.Core.Services;
using Ironclad.Shared.DTOs;

namespace Ironclad.Client.ConsoleApp;

class Program
{
    private static GameClient _gameClient;
    
    // Input loop and dictates how to show information.
    static async Task Main(string[] args)
    {
        _gameClient = new GameClient();
        await _gameClient.Start();
        
        // Input loop
        while (_gameClient.GameActive)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            await HandleInput(key);
        }
    }

    private static async Task HandleInput(ConsoleKeyInfo key)
    {
        switch (key.Key)
        {
            case ConsoleKey.P:
                //Console.WriteLine(GameState.Player.Name);
                
                await PlayerActions.RequestGameState();
                Console.WriteLine(GameState.Player);
                break;
                // Play Card "menu"
            case ConsoleKey.E:
                break;
                // End Turn
            case ConsoleKey.Escape:
                _gameClient.GameActive = false;
                break;
        }
    }
}