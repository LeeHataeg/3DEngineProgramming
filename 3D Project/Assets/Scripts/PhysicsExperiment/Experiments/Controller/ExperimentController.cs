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

    private IExperiment curExperiment;
    private PlanetType type;
    private FreeFallExperiment freeFall;
    private ParabolaExperiment parabola;

    [Header("VIEWS")]
    [SerializeField] private PlanetEnvironmentView environmentView;
    private TargetView targetView;

    [Header("SETTING")]

    private float endY = 0.5f;
    private Vector3 offset;
    private Vector3 newPos;


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

    private void FreeFallRoop()
    {
        if (curExperiment == null || !enabled || targetView == null) return;

        time += Time.fixedDeltaTime;

        offset = curExperiment.UpdatePhysics(time);
        newPos = curExperiment.StartPos + offset;

        if (newPos.y <= endY)
        {
            newPos.y = endY;
            targetView.SetPosition(newPos);
            enabled = false;
            return;
        }

        targetView.SetPosition(newPos);
    }

    private void ParabolaRoop()
    {
        if (curExperiment == null || !enabled || targetView == null) return;

        offset = curExperiment.UpdatePhysics(Time.fixedDeltaTime);
        newPos = curExperiment.StartPos + offset;

        if (newPos.y <= endY)
        {
            newPos.y = endY;
            targetView.SetPosition(newPos);
            enabled = false;
            return;
        }

        targetView.SetPosition(newPos);
    }

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
        // 실험들 초기화
        freeFall = new FreeFallExperiment();
        parabola = new ParabolaExperiment();
        // temp : 초기 힘 외부 입력 -> 앵그리버드처럼? 드래그로?
        parabola.SetExeternalForce(new Vector3(5000f, 5000f, 0f));

        curExperiment = freeFall;

        // 떨어질 대상
        target = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        // 의 위치 정보 조작
        targetView = target.AddComponent<TargetView>();
        targetView.SetTargetObject(target);
        targetView.SetOriginPos(curExperiment.StartPos);

        // 행성 할당
        SetPlanet(planetSO.GetPlanetInfo(PlanetType.Earth));
    }

    private void FixedUpdate()
    {
        switch (curExperiment.EType)
        {
            case ExperimentType.freeFall:
                {
                    FreeFallRoop();
                    break;
                }
            case ExperimentType.parabola:
                {
                    ParabolaRoop();
                    break;
                }
        }
    }
}
