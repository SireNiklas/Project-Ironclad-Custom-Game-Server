using System.Collections.Concurrent;
using Ironclad.Server.Core.Game;
using Ironclad.Server.Core.Models;
using Ironclad.Shared.DTOs;
using Microsoft.AspNetCore.SignalR;

namespace Ironclad.Server.Api.Hubs;

public class GameHub : Hub
{
    
    /*Send to client:

    Their own hand (all card details)
    Number of cards in opponent's hand (but not the actual cards)
    Cards played/visible on table
    Public information (turn order, player health, etc.)
    Game phase/turn status

    Don't send:

    Opponent's cards in hand
    Cards still in deck
    Any hidden information
    Internal game state variables*/
    
    /*E.G.
     // Send just their initial view state
    public async Task SendPlayerGameState(string playerName)
    {
        var player = _gameState.GetPlayer(playerName);
        var viewState = new PlayerViewState
        {
            Hand = player.Hand,
            OpponentCardCount = _gameState.GetOpponentCardCount(playerName),
            PublicGameInfo = _gameState.GetPublicInfo()
        };
        
        await Clients.Client(GetConnectionIdFromName(playerName))
            .SendAsync("UpdateGameState", viewState);
    }*/
    
    
    private static readonly ConcurrentDictionary<string, string> _connectionMap = new ConcurrentDictionary<string, string>();
    
    public override async Task OnConnectedAsync()
    {
        // Get PlayerId from database not from player, for now I am getting it from player.
        string playerName = Context.GetHttpContext().Request.Query["playerName"];

        if (!string.IsNullOrEmpty(playerName))
        {
            _connectionMap.TryAdd(playerName, Context.ConnectionId);
        }

        if (playerName != null)
        {

            Player player = new Player(Context.ConnectionId, playerName);
            GameState.Players.Add(player);

            await Clients.Client(Context.ConnectionId).SendAsync("GameConnected", $"{playerName} is connected");
        }

        await base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        string playerName = _connectionMap.FirstOrDefault(x => x.Key == Context.ConnectionId).Key;
        if(playerName != null)
            _connectionMap.TryRemove(playerName, out _);
        return base.OnDisconnectedAsync(exception);
    }

    public string GetNameFromConnectionId(string connectionId)
    {
        string playerName = _connectionMap.FirstOrDefault(x => x.Value == connectionId).Key;
        if (playerName != null)
            return playerName;
        else 
            return "Player not found";
    }

    public string GetConnectionIdFromName(string playerName)
    {
        _connectionMap.TryGetValue(playerName, out string connectionId);
        if (connectionId != null)
            return connectionId;
        else 
            return "Connection not found";
    }

    public async Task SendGameState()
    {
        try
        {
            // Make sure we have a current player set
            if (GameState.CurrentPlayer == null && GameState.Players.Any())
            {
                GameState.CurrentPlayer = GameState.Players.First();
            }

            GameStateDTO gameState = new GameStateDTO(
                GameState.CurrentPlayer.ToDTO(),
                GameState.CurrentTurn,
                GameState.CurrentPhase
            );

            await Clients.Caller.SendAsync("UpdatedGameState", gameState);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw; // Re-throw to let SignalR handle the error
        }
    }
    
    public async Task PlayCardRPC(CardDTO cardDTO)
    {
        // Use gamelogic to verify this is okay, and if so send the result.
        await Clients.Others.SendAsync("PlayedCard", cardDTO);
    }

    public async Task SendCoolMessageToOtherPlayer(string playerName, string message)
    {
        await Clients.Client(Context.ConnectionId).SendAsync("SentCoolMessage", $"{GetNameFromConnectionId(Context.ConnectionId)} : {message}");
        await Clients.Client(GetConnectionIdFromName(playerName)).SendAsync("SentCoolMessageToOtherPlayer", $"{GetNameFromConnectionId(Context.ConnectionId)} : {message}");
    }
    
    public async Task EndTurnRPC(string playerName)
    {
    }
}