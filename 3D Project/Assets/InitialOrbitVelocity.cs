using UnityEngine;

public class InitialOrbitVelocity : MonoBehaviour
{
    public Rigidbody planetRb;
    public Rigidbody sunRb;

    void Start()
    {
        Vector3 direction = planetRb.position - sunRb.position;
        float distance = direction.magnitude;

        // GravitySimulationÀÇ gravitationalConstant ÂüÁ¶
        float G = GravitySimulation.Instance.gravitationalConstant;

        float initialSpeed = Mathf.Sqrt(G * sunRb.mass / distance);

        Vector3 initialVelocity = Vector3.Cross(direction.normalized, Vector3.up).normalized * initialSpeed;

        planetRb.linearVelocity = initialVelocity;
    }
}
