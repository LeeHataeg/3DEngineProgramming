using UnityEngine;

public interface IExperiment
{
    void SetForce(Vector3 force);
    void StartExperiment(PlanetType planetType);
    void ResetExperiment();
    void FinishExperiment();
}
