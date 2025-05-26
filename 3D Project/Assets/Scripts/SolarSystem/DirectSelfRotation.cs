using UnityEngine;

public class DirectSelfRotation : MonoBehaviour
{
    [Header("태양 참조")]
    public Transform sun;         // 태양 Transform
    public Rigidbody sunRb;       // 태양 Rigidbody

    [Header("중력 상수")]
    public float gravityConstant = 7f;

    [Header("자전 관련")]
    public float rotationCount = 0f;    // 공전 1회당 자전 횟수
    public float axialTilt = 0f;       // 자전축 기울기

    private float rotationSpeed;          // 계산된 자전 속도 (도/초)

    void Start()
    {
        // 자전축 기울기 적용
        transform.rotation = Quaternion.Euler(axialTilt, 0f, 0f);

        // 태양과의 거리 r
        float r = Vector3.Distance(transform.position, sun.position);

        // 태양 질량
        float M = sunRb.mass;

        // 공전 주기 T (초 단위)
        float T = 2f * Mathf.PI * Mathf.Sqrt(Mathf.Pow(r, 3f) / (gravityConstant * M));

        // 자전 속도 (도/초)
        rotationSpeed = (360f * rotationCount) / T;
    }

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.Self);
    }
}
