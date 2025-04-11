using UnityEngine;
using UnityEngine.UI;

public class ExperimentController : MonoBehaviour
{
    public static ExperimentController Instance;

    [Header("EXPERIMENT_INFO")]
    private IExperiment curExperiment;
    [SerializeField] private Rigidbody rigid;
    [SerializeField] private PlanetInfoSO planetInfoSO; // gravity, air ... etc ...

    [Header("USER_INTERACTION")]
    [SerializeField] private Button startBtn;
    [SerializeField] private Button resetBtn;
    [SerializeField] private Button stopBtn;

    private Vector3 originPos;
    private Vector3 externalForce;

    private void Awake()
    {
        if(Instance == null)
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

        //temp
        StartExperiment(PlanetType.Earth);
    }

    public void SetExperiment()
    {
        //
    }

    public void StartExperiment(PlanetType planetType)
    {
        // User Input
        curExperiment = new FreeFallExperiment(planetType);
    }

    //
}
