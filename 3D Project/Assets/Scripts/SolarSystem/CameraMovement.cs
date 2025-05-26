using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 50f;          // 이동 속도
    public float zoomSpeed = 5000f;         // 줌 속도 (마우스 휠)
    public float rotationSpeed = 3f;        // 회전 속도
    public float minHeight = 10f;          // 줌인 제한
    public float maxHeight = 500f;         // 줌아웃 제한

    private float rotationX = 90f;
    private float rotationY = 0f;

    void Start()
    {
        // 초기 수직 시점 고정
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }

    void Update()
    {
        // WASD 이동
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, 0, v) * moveSpeed * Time.deltaTime;
        transform.Translate(move, Space.World); // 월드 기준 이동

        // 마우스 휠 줌
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 zoom = transform.position + Vector3.down * scroll * zoomSpeed * Time.deltaTime;

        // 높이 제한 적용
        if (zoom.y >= minHeight && zoom.y <= maxHeight)
        {
            transform.position = zoom;
        }

        if (Input.GetMouseButton(1)) // 오른쪽 클릭 누르고 있을 때
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            rotationY += mouseX * rotationSpeed;
            rotationX -= mouseY * rotationSpeed;
            rotationX = Mathf.Clamp(rotationX, 20f, 90f); // 시점 제한 (위아래)

            transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);
        }
    }
}
