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
        // 선택된 행성의 중력을 사용해 자유 낙하 실험 초기화
    }

    public override void ResetExperiment()
    {
        // 자유 낙하 시뮬레이션 업데이트 (예: 낙하 속도 계산)
    }

    public override void FinishExperiment()
    {
        // 실험 종료 후 원래 상태로 복원 작업
        base.FinishExperiment();
    }
}
