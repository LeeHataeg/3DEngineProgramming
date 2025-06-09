using UnityEngine;

public interface IExperiment
{
    ExperimentType EType { get; }
    
    Vector3 StartPos { get; }

    public void SetPlanetData(PlanetInfo type);
}
