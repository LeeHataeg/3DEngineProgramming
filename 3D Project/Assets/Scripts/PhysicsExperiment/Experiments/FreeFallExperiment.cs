using Unity.VisualScripting;
using UnityEngine;

public class FreeFallExperiment : BaseExperiment
{
    // temp -> this data will be moved in DataManager.cs
    

    public FreeFallExperiment(PlanetType planet) : base(planet) 
    { 
        // TODO - fill this val
        SetExperiment(new Vector3(0, 5.5f, 0), Vector3.zero);
    }

    public override void StartExperiment()
    {
        base.StartExperiment();
        // ���õ� �༺�� �߷��� ����� ���� ���� ���� �ʱ�ȭ
    }

    public override void ResetExperiment()
    {
        // ���� ���� �ùķ��̼� ������Ʈ (��: ���� �ӵ� ���)
    }

    public override void FinishExperiment()
    {
        // ���� ���� �� ���� ���·� ���� �۾�
        base.FinishExperiment();
    }
}
