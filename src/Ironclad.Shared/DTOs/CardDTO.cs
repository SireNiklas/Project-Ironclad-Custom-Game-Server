namespace Ironclad.Shared.DTOs;

public record CardDTO(
    string Name,
    int Attack,
    int Defense,
    int Cost
    );