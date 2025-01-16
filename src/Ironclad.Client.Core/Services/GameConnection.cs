using System.Diagnostics;
using Ironclad.Client.Core.Game;
using Ironclad.Client.Core.Interfaces;
using Ironclad.Shared.DTOs;
using Microsoft.AspNetCore.SignalR.Client;

namespace Ironclad.Client.Core.Services;

public class GameConnection : IGameConnection
{
    private static GameConnection _instance;
    private static readonly object _lock = new object();
    private HubConnection? _hubConnection;
    public event EventHandler<string>? OnConnected;
    public event EventHandler<GameStateDTO>? UpdatedGameState;
    public event EventHandler<CardDTO>? OnCardPlayedReceived;

    public string playerName { get; set; }
    
    // Singleton accessor
    public static GameConnection Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    _instance ??= new GameConnection();
                }
            }
            return _instance;
        }
    }
    
    public async Task ConnectAsync(string serverUrl)
    {
        _hubConnection = new HubConnectionBuilder().WithUrl($"{serverUrl}?playerName={playerName}").Build();
        PlayerActions.Initialize(_hubConnection);
        

        // Register Handlers
        _hubConnection.On<GameStateDTO>("UpdatedGameState", (gameStateDTO)
            => UpdatedGameState?.Invoke(this, gameStateDTO));
        
        _hubConnection.On<CardDTO>("PlayedCard", (cardDTO)
            => OnCardPlayedReceived?.Invoke(this, cardDTO));
        
        _hubConnection.On<string>("GameConnected", (message)
            => OnConnected?.Invoke(this, message));
        
        await _hubConnection.StartAsync();
    }

    public async Task DisconnectAsync()
    {
        if (_hubConnection != null)
            await _hubConnection.StopAsync();
    }
    
    public async Task GetNameAsync(string playerName, string message)
    {
        await _hubConnection.InvokeAsync("SendCoolMessageToOtherPlayer", playerName, message);
    }
}