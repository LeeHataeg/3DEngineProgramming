using UnityEngine;

public abstract class BaseExperiment : IExperiment
{
    protected PlanetType planetType;

    protected Rigidbody rigid;

    protected Vector3 originPos;
    protected Vector3 externalForce;//???

    public BaseExperiment(PlanetType planetType)
    {
        this.planetType = planetType;
    }
    // �� ���� UI�� ���� �ܺ� �Է� ���� �� ����.
    public void SetExperiment(Vector3 pos, Vector3 externalForce)
    {
        // I'll change this object into assets(like ball)
        GameObject target = new GameObject("target");
        rigid = target.AddComponent<Rigidbody>();
        rigid.useGravity = false;

        SetPos(pos);
        SetForce(externalForce);
    }

    public virtual void SetPos(Vector3 pos)
    {
        this.originPos = pos;
        rigid.position = originPos;
    }


    public virtual void SetForce(Vector3 force)
    {
        externalForce = force;
    }

    public virtual void StartExperiment()
    {
        rigid.useGravity = true;
        rigid.transform.position = originPos;
        rigid.AddForce(externalForce);
    }

    public virtual void ResetExperiment()
    {
        // �̰� �ǳ�? �� ������ '���� �ۿ� ���̴� �����
        // ���� ä�� ������ �� �������� ���� ���ϰڴ�' �̰ǵ�, linearVelocity�� addforce
        // ��������?
        rigid.useGravity = false;
        rigid.transform.position = originPos;
        rigid.linearVelocity = Vector3.zero;
        rigid.AddForce(externalForce);
    }

    public virtual void FinishExperiment()
    {
        rigid.useGravity = false;
        rigid.transform.position = originPos;
        externalForce = Vector3.zero;
        rigid.gameObject.SetActive(false);
    }
}
