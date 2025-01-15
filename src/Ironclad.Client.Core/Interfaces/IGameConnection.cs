using Ironclad.Shared.DTOs;

namespace Ironclad.Client.Core.Interfaces;

public interface IGameConnection
{
    // Methods for initiating SignalR connections and disconnections
    Task ConnectAsync(string serverUrl);
    Task DisconnectAsync();
    
    Task SendMessageAllAsync(string message);
    Task SendMessageOthersAsync(string message);
    Task SendMessageCallerAsync(string message);
    
    Task PlayCardAsync(CardDTO data);
    
    // Events for game state updates
    event EventHandler<string> OnMessageAllReceived; // TEMP: TEST EVENT!
    event EventHandler<string> OnMessageOthersReceived; // TEMP: TEST EVENT!
    event EventHandler<string> OnMessageCallerReceived; // TEMP: TEST EVENT!
    event EventHandler<CardDTO> OnCardPlayedReceived; // TEMP: TEST EVENT!
}