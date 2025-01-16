using Ironclad.Shared.DTOs;

namespace Ironclad.Server.Core.Models;

public class Mech
{
    public Part Torso { get; set; }
    public Part LeftArm { get; set; }
    public Part RightArm { get; set; }
    public Part LeftLeg { get; set; }
    public Part RightLeg { get; set; }

    public Mech()
    {
        Torso = new Part("Torso",100);
        LeftArm = new Part("Left Arm",100);
        RightArm = new Part("Right Arm",100);
        LeftLeg = new Part("Left Leg",100);
        RightLeg = new Part("Right Leg",100);
    }
    
}

public static class MechExtensions
{
    public static MechDTO ToDTO(this Mech mech)
    {
        return new MechDTO(
            mech.Torso.ToDTO(),
            mech.LeftArm.ToDTO(),
            mech.RightArm.ToDTO(),
            mech.LeftLeg.ToDTO(),
            mech.RightLeg.ToDTO()
        );
    }
}