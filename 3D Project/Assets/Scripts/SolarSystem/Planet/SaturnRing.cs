using UnityEngine;

public class SaturnRing : MonoBehaviour
{
    public float axialTilt = 0f;
    void Start()
    {
        transform.rotation = Quaternion.Euler(axialTilt, 0f, 0f);
    }
}
