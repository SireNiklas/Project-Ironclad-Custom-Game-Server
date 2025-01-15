namespace Ironclad.Server.Core.Models;

public class Part
{
    public int Health {get; set;}

    public Part(int health)
    {
        Health = health;
    }
}