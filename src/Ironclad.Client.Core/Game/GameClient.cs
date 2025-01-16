using System.Diagnostics;
using Ironclad.Client.Core.Services;
using Ironclad.Shared.DTOs;

namespace Ironclad.Client.Core.Game;

public class GameClient
{
    
    // Gets information from the server, sets it up to be used by the client UI. (Handles communication, connection, and transmutation)
    
    private static readonly GameConnection _gameConnection = new GameConnection();
    public static GameConnection GameConnection => _gameConnection;
    
    private bool _isMyTurn = false;
    public bool GameActive = false;
    
    public async Task Start()
    {
        // Registar Player (This should be where authentication happens I think?
        Console.Write("Please enter a username: ");
        _gameConnection.playerName = Console.ReadLine();
        
        // Connect to server AFTER I give my user information
        await ConnectToServer();
        Run();
    }

    private async Task ConnectToServer()
    {
        await _gameConnection.ConnectAsync("http://localhost:5177/game");
        Console.WriteLine("Connected to server");

        RegisterHandlers();
    }
    
    private void RegisterHandlers()
    {
        _gameConnection.OnConnected += (sender, message) => Console.WriteLine($"Server: {message}");
        _gameConnection.UpdatedGameState += (sender, serverGameState) => GameState.UpdateGameState(serverGameState);
        _gameConnection.OnCardPlayedReceived += (sender, cardDTO) => Console.WriteLine($"{cardDTO.Name} : {cardDTO.Attack} : {cardDTO.Defense} : {cardDTO.Cost}");
    }

    public void Run()
    {
        // Send data to the server???
        GameActive = true;
    }

    public async Task Stop()
    {
        if (_gameConnection != null)
        {
            await _gameConnection.DisconnectAsync();
        }
    }
}