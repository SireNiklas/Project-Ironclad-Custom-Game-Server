using Ironclad.Server.Core.Models;
using Ironclad.Server.Shared.Enums;

namespace Ironclad.Server.Core.Game;

public static class GameState
{
    
    // Player/Turns/Phase
    public static List<Player> Players { get; set; } = new List<Player>();
    public static Player? CurrentPlayer { get; set; }
    public static int CurrentPlayerIndex { get; set; }
    public static int CurrentTurn { get; set; }
    public static Phase CurrentPhase { get; set; }
    
    // Game Status
    public static GameStatus CurrentGameStatus { get; set; }
    public static Player Winner { get; set; }
    public static bool IsGameOver { get; set; }
    
    // Game Config (Add if custom things)

    public static void InitializeGame()
    {
        Console.WriteLine($"{CurrentPlayer.Name} : {CurrentPlayer.Attack} : {CurrentPlayer.Defense} : {CurrentPlayer.Scrap} : {CurrentPlayer.Health} : {CurrentPlayer.MaxHealth} : {CurrentPlayer.Hand.Cards.Count} : {CurrentPlayer.Deck.Cards.Count} : {CurrentPlayer.Mech} : {CurrentPlayer.Mech.Torso}");
    }

    public static void EndTurn()
    {
        CurrentPlayerIndex = (CurrentPlayerIndex + 1) % Players.Count;
    }
}