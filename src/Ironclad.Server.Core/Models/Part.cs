using Ironclad.Shared.DTOs;

namespace Ironclad.Server.Core.Models;

public class Part
{
    public string Name { get; set; }
    public int Health {get; set;}

    public Part(string name, int health)
    {
        Name = name;
        Health = health;
    }
}

public static class PartExtensions
{
    public static PartDTO ToDTO(this Part part)
    {
        return new PartDTO(
            part.Name,
            part.Health
        );
    }
}