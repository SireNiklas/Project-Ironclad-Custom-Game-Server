namespace Ironclad.Shared.DTOs;

public record PlayerDTO(
    string Name,
    int Attack,
    int Defense,
    int Health,
    int Scrap,
    HandDTO Hand,
    MechDTO Mech
    );