using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    public Transform target; // �༺ �Ǵ� �¾� (���� ���)
    public float height = 50f; // ī�޶��� ����

    void Start()
    {
        if (target != null)
        {
            // ī�޶��� ��ġ�� ��� �������� �̵�
            transform.position = new Vector3(target.position.x, target.position.y + height, target.position.z);
            // �Ʒ������� �����ٺ����� ����
            transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        }
        else
        {
            Debug.LogError("Ÿ���� �������ּ���.");
        }
    }
}
