using UnityEngine;

public abstract class BaseExperiment : IExperiment
{
    protected ExperimentType experimentType;

    public ExperimentType EType => experimentType;

    private Vector3 pos;

    public Vector3 CurrentPosition => pos;

    public abstract void SetPlanetData(PlanetInfo type);
    public abstract Vector3 UpdatePhysics(float dt);
}
