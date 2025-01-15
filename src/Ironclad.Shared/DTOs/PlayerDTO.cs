namespace Ironclad.Shared.DTOs;

public record PlayerDTO(
    int Id,
    string Name,
    int Attack,
    int Defense,
    int Health,
    int Scrap,
    HandDTO Hand,
    MechDTO Mech
    );