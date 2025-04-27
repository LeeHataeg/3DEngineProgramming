using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    // 태양 참조 (거리, 질량 계산용)
    public Transform sun;
    public Rigidbody sunRb;

    // 중력 상수 (GravitySimulation.cs에서 사용한 값과 동일)
    public float gravityConstant = 7f;

    // 공전 한 바퀴 도는 동안 자전 횟수 (예: 지구는 365)
    public float rotationCount = 365f;

    // 자전축 기울기 (단위: 도)
    public float axialTilt = 23.5f;

    private float rotationSpeed;    // 계산된 자전 속도 (도/초)
    private Transform axisPivot;    // 자전 축 역할의 부모 객체

    void Start()
    {
        // 공전 주기 계산 (케플러 법칙 기반)
        float r = Vector3.Distance(transform.position, sun.position);
        float T = 2 * Mathf.PI * Mathf.Sqrt(Mathf.Pow(r, 3) / (gravityConstant * sunRb.mass));

        // 자전 속도 계산 (자전 횟수에 맞게 도/초 환산)
        rotationSpeed = (360f * rotationCount) / T;

        // 자전축 오브젝트 생성 및 기울기 적용
        axisPivot = new GameObject(name + "_Axis").transform;
        axisPivot.position = transform.position;
        axisPivot.rotation = Quaternion.Euler(axialTilt, 0f, 0f);

        // 행성을 자전축의 자식으로 설정
        transform.SetParent(axisPivot);
    }

    void Update()
    {
        // 자전축 기준으로 회전
        axisPivot.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
