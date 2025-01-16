using Ironclad.Shared.DTOs;

namespace Ironclad.Server.Core.Models;

public class Player
{
    // Maybe use "GUID"
    public string ConnectionId { get; set; }
    public string Name { get; set; }
    public int Attack { get; set; } = 0;
    public int Defense { get; set; } = 0;
    public int Health { get; set; } = 100;
    public int MaxHealth { get; set; } = 100;

    public int Scrap { get; set; } = 0;
    
    public Hand Hand { get; set; }
    public Deck Deck { get; set; }
    public Mech Mech { get; set; }
    
    public Player(string connectionId, string name)
    {
        ConnectionId = connectionId;
        Name = name;
        Hand = new Hand();
        Deck = new Deck();
        Mech = new Mech();
    }
    
    // Add methods for player.
}

public static class PlayerExtensions
{
    public static PlayerDTO ToDTO(this Player player)
    {
        return new PlayerDTO(
            player.Name,
            player.Attack,
            player.Defense,
            player.Health,
            player.Scrap,
            HandExtensions.ToDTO(player.Hand),
            MechExtensions.ToDTO(player.Mech)
        );
    }
}