namespace Ironclad.Server.Core.Models;

public class Deck
{
    public List<Card> Cards { get; set; } = new List<Card>();
    
    public Deck() { }
}