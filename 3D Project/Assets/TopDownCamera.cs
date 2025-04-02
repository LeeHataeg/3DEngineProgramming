using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    public Transform target; // 행성 또는 태양 (초점 대상)
    public float height = 50f; // 카메라의 높이

    void Start()
    {
        if (target != null)
        {
            // 카메라의 위치를 대상 위쪽으로 이동
            transform.position = new Vector3(target.position.x, target.position.y + height, target.position.z);
            // 아래쪽으로 내려다보도록 설정
            transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        }
        else
        {
            Debug.LogError("타겟을 설정해주세요.");
        }
    }
}
