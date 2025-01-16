using Ironclad.Server.Shared.Enums;

namespace Ironclad.Shared.DTOs;

public record GameStateDTO(
    // Global Information
    PlayerDTO CurrentPlayer,
    int CurrentTurn,
    Phase CurrentPhase
    
    // // Player Information
    // HandDTO CurrentHand,
    // int PlayerHealth,
    //
    // // Opponent Information
    // // Hand Count,
    // int OpponentHealth,
    // int OpponentName
    
    // Game State
    // Cards in play
    // Whos turn
    );