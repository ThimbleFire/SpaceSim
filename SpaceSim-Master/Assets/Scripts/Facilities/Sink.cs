using System.Collections.Generic;

public class Sink : Facility
{
    public override bool Interact( ref List<float> impulse ) {
        impulse[2] += Entity.ImpulseMax / 7;
        return impulse[2] >= Entity.ImpulseMax ? true : false;
    }
}
