using UnityEngine;

public interface IExperiment
{
    ExperimentType EType { get; }

    public void SetPlanetData(PlanetInfo type);
    Vector3 UpdatePhysics(float dt);
    Vector3 CurrentPosition { get; }
}
