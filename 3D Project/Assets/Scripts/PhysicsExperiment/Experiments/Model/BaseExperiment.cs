using UnityEngine;

public abstract class BaseExperiment : IExperiment
{
    // 실험 타입
    protected ExperimentType experimentType;

    public ExperimentType EType => experimentType;

    // 시작 위치
    protected Vector3 startPos;

    public Vector3 StartPos => startPos;

    // 현재 위치
    private Vector3 pos;

    public Vector3 CurrentPosition => pos;

    

    public abstract void SetPlanetData(PlanetInfo type);
    public abstract Vector3 UpdatePhysics(float dt);
}
