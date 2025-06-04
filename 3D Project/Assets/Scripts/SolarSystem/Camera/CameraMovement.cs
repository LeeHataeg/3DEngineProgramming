using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 50f;
    public float zoomSpeed = 5000f;
    public float rotationSpeed = 3f;
    public float minHeight = 10f;
    public float maxHeight = 500f;

    private float rotationX = 90f;
    private float rotationY = 0f;

    void Start()
    {
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }

    void Update()
    {
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        // 입력을 GetAxisRaw로 바꾸기 (시간 정지에 무관)
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 move = (forward * v + right * h) * moveSpeed * Time.unscaledDeltaTime;
        transform.position += move;

        // 마우스 휠도 시간 무관하게 처리됨
        float scroll = Input.GetAxisRaw("Mouse ScrollWheel");
        Vector3 zoom = transform.position + transform.forward * scroll * zoomSpeed * Time.unscaledDeltaTime;

        if (zoom.y >= minHeight && zoom.y <= maxHeight)
        {
            transform.position = zoom;
        }

        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxisRaw("Mouse X");
            float mouseY = Input.GetAxisRaw("Mouse Y");

            rotationY += mouseX * rotationSpeed;
            rotationX -= mouseY * rotationSpeed;
            rotationX = Mathf.Clamp(rotationX, 20f, 90f);

            transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);
        }
    }
}
