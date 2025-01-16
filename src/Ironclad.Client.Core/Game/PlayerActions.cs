using System.Diagnostics;
using Ironclad.Shared.DTOs;
using Microsoft.AspNetCore.SignalR.Client;

namespace Ironclad.Client.Core.Game;

public static class PlayerActions
{
    private static HubConnection _hubConnection;
    
    public static void Initialize(HubConnection hubConnection)
    {
        _hubConnection = hubConnection;
    }
    
    public static async Task PlayCardRequest(CardDTO card)
    {
        Debug.Assert(_hubConnection != null, nameof(_hubConnection) + " != null");
        await _hubConnection.InvokeAsync("PlayCardRPC", card);
    }
    
    public static async Task RequestGameState()
    {
        Debug.Assert(_hubConnection != null, nameof(_hubConnection) + " != null");
        await _hubConnection.InvokeAsync("SendGameState");
    }
}