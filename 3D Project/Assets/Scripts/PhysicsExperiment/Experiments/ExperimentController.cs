using UnityEngine;
using UnityEngine.UI;

public class ExperimentController : MonoBehaviour
{
    public static ExperimentController Instance;

    [Header("EXPERIMENT_INFO")]
    private IExperiment curExperiment;
    [SerializeField] private Rigidbody rigid;
    [SerializeField] private PlanetInfoSO planetInfoSO; // gravity, air ... etc ...

    // TODO - �� �ڵ嵵 ExperimentUI.cs �� UI ���� �ڵ�� �Űܰ� ����
    [Header("USER_INTERACTION")]
    [SerializeField] private Button startBtn;
    [SerializeField] private Button resetBtn;
    [SerializeField] private Button stopBtn;

    private void Awake()
    {
        if(Instance == null)
            Instance = new ExperimentController();
        else
            Destroy(Instance);
    }

    // �ϴ� ���� ���� ���ѹ������� -> �༺�� ���� ����� ���� ���� -> UI�� �ܺ���
    void Start()
    {
        //m_firstButton.onClick.AddListener(OnClickButton);
        //m_secondButton.onClick.AddListener(() => OnClickButtonWithParameters(2));
        //m_secondButton.onClick.AddListener(delegate { Debug.Log("clicked second button"); });
        //m_thirdButton.onClick.AddListener(OnClickButton);

        //temp - �ӽ� ��
        curExperiment = new FreeFallExperiment(PlanetType.Earth);
        StartExperiment(PlanetType.Earth);
    }

    public void SetExperiment()
    {
        //
    }

    // TODO - planettype�� �ƴ϶� planetSO�� �����͸� �Ѱ��� ��?
    public void StartExperiment(PlanetType planetType)
    {
        // User Input
        curExperiment.StartExperiment();
    }
}
