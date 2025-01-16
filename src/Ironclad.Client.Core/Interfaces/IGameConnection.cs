using Ironclad.Shared.DTOs;

namespace Ironclad.Client.Core.Interfaces;

public interface IGameConnection
{
    // Methods for initiating SignalR connections and disconnections
    Task ConnectAsync(string serverUrl);
    Task DisconnectAsync();
    
    // Events for game state updates
    event EventHandler<string> OnConnected;
    event EventHandler<GameStateDTO> UpdatedGameState;
    event EventHandler<CardDTO> OnCardPlayedReceived;
}