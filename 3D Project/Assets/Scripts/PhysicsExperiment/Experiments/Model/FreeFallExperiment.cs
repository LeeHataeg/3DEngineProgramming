using System;
using Unity.VisualScripting;
using UnityEngine;

public class FreeFallExperiment : BaseExperiment
{

    public FreeFallExperiment()
    {
        experimentType = ExperimentType.freeFall;
    }

    public override void SetPlanetData(PlanetInfo type)
    {
        Physics.gravity = new Vector3(0, -1 * type.GravityAccel, 0);
    }
}
