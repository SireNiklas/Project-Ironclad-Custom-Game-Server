using Ironclad.Shared.DTOs;
using Microsoft.AspNetCore.SignalR;

namespace Ironclad.Server.Api.Hubs;

public class GameHub : Hub
{
    public async Task SendMessageToAll(string message) => await Clients.All.SendAsync("ReceiveMessageAll", message);
    public async Task SendMessageToOthers(string message) => await Clients.Others.SendAsync("ReceiveMessageOthers", message);
    public async Task SendMessageToCaller(string message) => await Clients.Caller.SendAsync("ReceiveMessageCaller", message);

    public async Task PlayCard(CardDTO cardDTO)
    {
        
        await Clients.All.SendAsync("PlayedCard", cardDTO);
    }
}