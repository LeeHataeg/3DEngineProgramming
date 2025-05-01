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

    [Header("MODELS")]
    [SerializeField] private PlanetInfoSO planetSO;

    [Header("VIEWS")]
    [SerializeField] private PlanetEnvironmentView environmentView;

    [Header("EXPERIMENT_INFO")]
    private IExperiment curExperiment;
    private PlanetType type;
    private FreeFallExperiment freeFall;

    // TODO - 이 코드도 ExperimentUI.cs 등 UI 관련 코드로 옮겨갈 예정
    [Header("USER_INTERACTION")]
    [SerializeField] private Button startBtn;
    [SerializeField] private Button resetBtn;
    [SerializeField] private Button stopBtn;

    private void Awake()
    {
        if (Instance == null)
            Instance = new ExperimentController();
        else
            Destroy(Instance);
    }

    // 일단 자유 낙하 시켜버리도록 -> 행성의 여러 상수값 영향 구현 -> UI와 외부힘
    void Start()
    {
        //m_firstButton.onClick.AddListener(OnClickButton);
        //m_secondButton.onClick.AddListener(() => OnClickButtonWithParameters(2));
        //m_secondButton.onClick.AddListener(delegate { Debug.Log("clicked second button"); });
        //m_thirdButton.onClick.AddListener(OnClickButton);

        //temp - 임시 값
        SetPlanet(PlanetType.Earth);
        freeFall = new FreeFallExperiment(type);

        curExperiment = freeFall;
        StartExperiment(type);
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

    // TODO - planettype이 아니라 planetSO의 데이터를 넘겨줄 듯?
    public void StartExperiment(PlanetType planetType)
    {
        // User Input
        curExperiment.StartExperiment(type);
    }

    public void SetPlanet(PlanetType type)
    {
        this.type = type;
    }
}
