namespace Ironclad.Server.Core.Models;

public class Deck
{
    public List<Card> Cards { get; set; } = new List<Card>();

    public Deck()
    {
        new List<Card>
        {
            new Card(0, "TestCard1", 5, 0, 0),
            new Card(1, "TestCard2", 2, 5, 0),
            new Card(2, "TestCard3", 5, 2, 0),
            new Card(3, "TestCard4", 4, 1, 0),
            new Card(4, "TestCard5", 7, 8, 0),
            new Card(5, "TestCard6", 1, 6, 0),
            new Card(6, "TestCard7", 2, 3, 0),
            new Card(7, "TestCard8", 5, 0, 0),
            new Card(8, "TestCard9", 2, 5, 0),
            new Card(9, "TestCard10", 5, 2, 0),
            new Card(10, "TestCard11", 4, 1, 0),
            new Card(11, "TestCard12", 7, 8, 0),
            new Card(12, "TestCard13", 1, 6, 0),
            new Card(13, "TestCard14", 2, 3, 0),
            new Card(15, "TestCard15", 5, 0, 0),
            new Card(16, "TestCard16", 2, 5, 0),
            new Card(17, "TestCard17", 5, 2, 0),
            new Card(18, "TestCard18", 4, 1, 0),
            new Card(19, "TestCard19", 7, 8, 0),
            new Card(20, "TestCard20", 1, 6, 0),
            new Card(21, "TestCard21", 2, 3, 0),
            new Card(22, "TestCard22", 5, 0, 0),
            new Card(23, "TestCard23", 2, 5, 0),
            new Card(24, "TestCard24", 5, 2, 0),
            new Card(25, "TestCard25", 4, 1, 0),
            new Card(26, "TestCard26", 7, 8, 0),
            new Card(27, "TestCard27", 1, 6, 0),
            new Card(28, "TestCard28", 2, 3, 0)
        };
    }
}