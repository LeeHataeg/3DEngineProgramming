using UnityEngine;

public class RotationSpeedRigidbody : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 angularVelocity = rb.angularVelocity;
        float degreesPerSecond = angularVelocity.magnitude * Mathf.Rad2Deg;
        Debug.Log($"{gameObject.name} 회전 속도: {degreesPerSecond} 도/초");
    }
}
