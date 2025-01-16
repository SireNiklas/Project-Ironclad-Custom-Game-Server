using Ironclad.Shared.DTOs;

namespace Ironclad.Server.Core.Models;

public class Hand
{
    public List<Card> Cards { get; set; } = new();

    public Hand()
    {
        new List<Card>
        {
            new Card(0, "TestCard1", 5, 0, 0),
            new Card(1, "TestCard2", 2, 5, 0),
            new Card(2, "TestCard3", 5, 2, 0),
            new Card(3, "TestCard4", 4, 1, 0),
            new Card(4, "TestCard5", 7, 8, 0),
            new Card(5, "TestCard6", 1, 6, 0),
            new Card(6, "TestCard7", 2, 3, 0)
        };
    }
}

public static class HandExtensions
{
    public static HandDTO ToDTO(this Hand hand)
    {
        return new HandDTO(
            hand.Cards.Select(c => new CardDTO(c.Name, c.Attack, c.Defense, c.Cost)).ToList()
        );
    }
}