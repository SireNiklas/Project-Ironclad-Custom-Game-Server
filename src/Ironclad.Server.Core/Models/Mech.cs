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
        Torso = new Part(100);
        LeftArm = new Part(100);
        RightArm = new Part(100);
        LeftLeg = new Part(100);
        RightLeg = new Part(100);
    }
}