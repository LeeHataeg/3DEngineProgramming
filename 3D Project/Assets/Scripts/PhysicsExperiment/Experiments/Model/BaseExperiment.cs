using UnityEngine;

public abstract class BaseExperiment : IExperiment
{
    private Vector3 pos;

    public Vector3 CurrentPosition => pos;

    public abstract void UpdatePhysics(float dt);
}
