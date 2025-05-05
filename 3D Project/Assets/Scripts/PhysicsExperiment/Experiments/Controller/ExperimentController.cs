using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public enum ExperimentType
{
    freeFall,   // 자유 낙하 운동
    parabola    // 포물선 운동
}

public class ExperimentController : MonoBehaviour
{
    public static ExperimentController Instance;
    private float time = 0f;
    private GameObject target;

    [Header("MODELS")]
    [SerializeField] private PlanetInfoSO planetSO;

    [Header("VIEWS")]
    [SerializeField] private PlanetEnvironmentView environmentView;
    private TargetView targetView;

    [Header("EXPERIMENT_INFO")]
    private IExperiment curExperiment;
    private PlanetType type;
    private FreeFallExperiment freeFall;

    [Header("SETTING")]
    private float startY = 6f;
    private float endY = 0.5f;
    private Vector3 offset;
    private Vector3 newPos;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);
    }

    // 일단 자유 낙하 시켜버리도록 -> 행성의 여러 상수값 영향 구현 -> UI와 외부힘
    void Start()
    {
        //temp - 임시 값
        target = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        targetView = target.AddComponent<TargetView>();
        targetView.SetTargetObject(target);
        targetView.SetOriginPos(new Vector3(0, startY, 0));

        freeFall = new FreeFallExperiment();
        curExperiment = freeFall;

        SetPlanet(planetSO.GetPlanetInfo(PlanetType.Earth));
    }
    public void SetPlanet(PlanetInfo planet)
    {
        curExperiment.SetPlanetData(planet);
        type = planet.Planet;
        environmentView.LoadEnvironment(type);
    }
    public void SetExperiment(ExperimentType eType)
    {
        switch (eType)
        {
            case ExperimentType.freeFall:
                curExperiment = freeFall;
                break;
            case ExperimentType.parabola:
                curExperiment = freeFall;
                break;
        }
    }

    private void FixedUpdate() 
    {
        switch (curExperiment.EType)
        {
            case ExperimentType.freeFall:
                FreeFallRoop();
                break;
            case ExperimentType.parabola:
                break;
        }
    }

    private void FreeFallRoop()
    {
        if (curExperiment == null || !enabled || targetView == null) return;

        time += Time.fixedDeltaTime;

        offset = curExperiment.UpdatePhysics(time);
        newPos = new Vector3(0, startY, 0) + offset;

        if (newPos.y <= endY)
        {
            newPos.y = endY;
            targetView.SetPosition(newPos);
            // 이후 더 이상 FixedUpdate가 돌아가지 않도록 비활성화
            enabled = false;
            Debug.Log("escape");
            return;
        }

        // 정상 위치 업데이트
        targetView.SetPosition(newPos);
    }
}
