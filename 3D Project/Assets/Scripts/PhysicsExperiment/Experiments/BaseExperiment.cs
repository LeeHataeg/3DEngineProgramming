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
    // 이 값은 UI에 의해 외부 입력 받을 수 있음.
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
        // 이거 되냐? 내 생각은 '기존 작용 중이던 운동량을
        // 씹은 채로 리셋한 후 가해지는 힘을 가하겠다' 이건데, linearVelocity가 addforce
        // 씹을지도?
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
