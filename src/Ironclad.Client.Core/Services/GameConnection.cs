using System.Diagnostics;
using Ironclad.Client.Core.Interfaces;
using Ironclad.Shared.DTOs;
using Microsoft.AspNetCore.SignalR.Client;

namespace Ironclad.Client.Core.Services;

public class GameConnection : IGameConnection
{
    private HubConnection? _hubConnection;

    public event EventHandler<string>? OnMessageAllReceived; 
    public event EventHandler<string>? OnMessageOthersReceived; 
    public event EventHandler<string>? OnMessageCallerReceived; 
    public event EventHandler<CardDTO>? OnCardPlayedReceived; 
    
    public async Task ConnectAsync(string serverUrl)
    {
        _hubConnection = new HubConnectionBuilder().WithUrl(serverUrl).Build();

        // Register Handlers
        _hubConnection.On<string>("ReceiveMessageAll", (message)
            => OnMessageAllReceived?.Invoke(this, message));
        
        _hubConnection.On<string>("ReceiveMessageOthers", (message)
            => OnMessageOthersReceived?.Invoke(this, message));
        
        _hubConnection.On<string>("ReceiveMessageCaller", (message)
            => OnMessageCallerReceived?.Invoke(this, message));
        
        _hubConnection.On<CardDTO>("PlayedCard", (cardDTO)
            => OnCardPlayedReceived?.Invoke(this, cardDTO));
        
        await _hubConnection.StartAsync();
    }

    public async Task DisconnectAsync()
    {
        if (_hubConnection != null)
            await _hubConnection.StopAsync();
    }

    public async Task SendMessageAllAsync(string message)
    {
        Debug.Assert(_hubConnection != null, nameof(_hubConnection) + " != null");
        await _hubConnection.InvokeAsync("SendMessageToAll", message);
    }

    public async Task SendMessageOthersAsync(string message)
    {
        Debug.Assert(_hubConnection != null, nameof(_hubConnection) + " != null");
        await _hubConnection.InvokeAsync("SendMessageToOthers", message);
    }
    
    public async Task SendMessageCallerAsync(string message)
    {
        Debug.Assert(_hubConnection != null, nameof(_hubConnection) + " != null");
        await _hubConnection.InvokeAsync("SendMessageToCaller", message);
    }
    
    public async Task PlayCardAsync(CardDTO cardDTO)
    {
        Debug.Assert(_hubConnection != null, nameof(_hubConnection) + " != null");
        await _hubConnection.InvokeAsync("PlayCard", cardDTO);
    }
}