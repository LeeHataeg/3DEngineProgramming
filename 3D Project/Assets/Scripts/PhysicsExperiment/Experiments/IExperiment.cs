using UnityEngine;

public interface IExperiment
{
    void SetForce(Vector3 force);
    void StartExperiment();
    void ResetExperiment();
    void FinishExperiment();
}
