using UnityEngine;

public class TargetView : MonoBehaviour
{
    private Transform trans;
    private Vector3 originPos;

    public void SetTargetObject(GameObject target)
    {
        // change target Object
        trans = target.transform;
    }

    public void ResetTarget()
    {
        trans.position = originPos;
    }

    public void SetOriginPos(Vector3 pos)
    {
        originPos = pos;
        SetPosition(originPos);
    }

    public void SetPosition(Vector3 newPos)
    {
        trans.position = newPos;
    }
}
