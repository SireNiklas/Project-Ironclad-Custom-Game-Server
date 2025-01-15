namespace Ironclad.Shared.DTOs;

public record MechDTO(
    PartDTO Torso,
    PartDTO LeftArm,
    PartDTO RightArm,
    PartDTO LeftLeg,
    PartDTO RightLeg
    );