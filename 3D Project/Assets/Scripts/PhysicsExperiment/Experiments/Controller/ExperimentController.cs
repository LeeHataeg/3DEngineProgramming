using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

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


    private void SetPlanet()
    {
        curExperiment.SetPlanetData(GameManager.Instance.SceneChangeManager.PlanetInfo);
        type = GameManager.Instance.SceneChangeManager.PlanetInfo.Planet;
        environmentView.LoadEnvironment(type);
    }

    private void SetExperiment()
    {
        // 실험들 초기화
        freeFall = new FreeFallExperiment();
        parabola = new ParabolaExperiment();
        // temp : 초기 힘 외부 입력 -> 앵그리버드처럼? 드래그로?
        parabola.SetExeternalForce(new Vector3(5000f, 5000f, 0f));
    }

    public void SelectExperiment(ExperimentType eType)
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

    #region Target
    private void SetTarget()
    {
        target = (GameObject)Resources.Load("Prefabs/Target");
        CreateTarget();
    }

    private void CreateTarget()
    {
        Instantiate(target);
        target.GetComponent<TargetView>().SetOriginPos(new Vector3(0, 6f, 0));
    }
    #endregion

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);
    }

    void Start()
    {
        SetExperiment();
        SelectExperiment(ExperimentType.freeFall);

        SetTarget();

        SetPlanet();
    }
}
