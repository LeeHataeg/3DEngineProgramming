using UnityEngine;

public interface IExperiment
{
    ExperimentType EType { get; }

    public void SetPlanetData(PlanetInfo type);
}
