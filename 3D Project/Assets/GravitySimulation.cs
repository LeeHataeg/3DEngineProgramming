using UnityEngine;

public class GravitySimulation : MonoBehaviour
{
    public static GravitySimulation Instance;

    public Rigidbody sunRb;
    public float gravitationalConstant = 10f;
    public Rigidbody[] planets;

    void Awake()
    {
        Instance = this;
    }

    void FixedUpdate()
    {
        foreach (Rigidbody planetRb in planets)
        {
            Vector3 direction = sunRb.position - planetRb.position;
            float distance = direction.magnitude;

            float forceMagnitude = gravitationalConstant * (sunRb.mass * planetRb.mass) / Mathf.Pow(distance, 2);
            Vector3 force = direction.normalized * forceMagnitude;

            planetRb.AddForce(force);
        }
    }
}
