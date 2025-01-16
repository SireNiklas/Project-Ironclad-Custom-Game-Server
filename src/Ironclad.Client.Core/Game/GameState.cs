using Ironclad.Server.Shared.Enums;
using Ironclad.Shared.DTOs;

namespace Ironclad.Client.Core.Game;

public static class GameState
{
    public static PlayerDTO Player { get; private set; } = 
        new PlayerDTO("Blobby", 0, 0, 0, 0,
        new HandDTO(
            new List<CardDTO>
            {
                new CardDTO("TestCard", 5, 2,0)
            }),
        new MechDTO(
            new PartDTO("Glock", 100), 
            new PartDTO("Bock", 100), 
            new PartDTO("Tock", 100), 
            new PartDTO("Clock", 100), 
            new PartDTO("Sock", 100)));
    public static int CurrentTurn { get; private set; }
    public static Phase CurrentPhase { get; private set; }

    public static void UpdateGameState(GameStateDTO serverState)
    {
        // Console.WriteLine($"Current game state: {serverState}");
        Player = serverState.CurrentPlayer;
        CurrentTurn = serverState.CurrentTurn;
        CurrentPhase = serverState.CurrentPhase;
    }
}