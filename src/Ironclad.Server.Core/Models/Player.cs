namespace Ironclad.Server.Core.Models;

public class Player
{
    // Maybe use "GUID"
    public string ConnectionId { get; set; }
    public string Name { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    
    public int Scrap { get; set; }
    
    public Hand Hand { get; set; }
    public Deck Deck { get; set; }
    public Mech Mech { get; set; }
    
    public Player(string connectionId, string name, int attack, int defense, int health, int maxHealth)
    {
        ConnectionId = connectionId;
        Name = name;
        Attack = attack;
        Defense = defense;
        Health = health;
        MaxHealth = maxHealth;
        
        Hand = new Hand();
        Deck = new Deck();
        Mech = new Mech();
    }
    
    // Add methods for player.
}