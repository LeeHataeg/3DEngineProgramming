using UnityEngine;

public interface IExperiment
{
    void UpdatePhysics(float dt);
    Vector3 CurrentPosition { get; }
}
