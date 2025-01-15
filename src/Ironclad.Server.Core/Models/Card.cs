namespace Ironclad.Server.Core.Models;

public class Card
{
    // Maybe use "GUID"
    public int Id { get; set; }
    public string Name { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Cost { get; set; }

    public Card(int id, string name, int attack, int defense, int cost)
    {
        Id = id;
        Name = name;
        Attack = attack;
        Defense = defense;
        Cost = cost;
    }
}