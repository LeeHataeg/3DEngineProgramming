using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class ExperimentController : MonoBehaviour
{
    private float time = 0f;
    [SerializeField]private GameObject[] targets;

    [Header("MODELS")]
    [SerializeField] private PlanetInfoSO planetSO;

    public IExperiment curExperiment;
    private PlanetType type;
    private FreeFallExperiment freeFall;
    private ParabolaExperiment parabola;

    [Header("VIEWS")]
    [SerializeField] private PlanetEnvironmentView environmentView;

    [Header("CONTROLLERS")]
    [SerializeField] private ExperimentStatUIController statUIController;

    [Header("SETTING_Freefall")]
    private Vector3 selectedTargetPos = new Vector3(500, 25, 525);
    private Vector3 earthTargetPos = new Vector3(-2500, 25, 525);

    private Vector3 earthGravity = new Vector3(0, -9.81f, 0);

    [Header("SETTING_Parabola")]
    private Vector3 force = new Vector3(0, 0, 0);

    private Vector3 leftStartPos = new Vector3(0, 0, 0);
    private Vector3 rightStartPos = new Vector3(0, 0, 0);

    private GameObject leftObj;
    private GameObject rightObj;

    // TODO - 이걸 스크립트 상에서 오브젝트 크기 탐지하여 설정하도록?
    // 터미널 속도값들(m/s)
    // 표면적, 질량, 반경에 영향을 받는다.
    private readonly Dictionary<TargetType, float> desiredVt =
        new Dictionary<TargetType, float>
        {
            [TargetType.Baseball] = 33f,
            [TargetType.Basketball] = 21f,
            [TargetType.Football] = 19f,
            [TargetType.Soccer] = 19f,
            [TargetType.Volleyball] = 16f
        };


    private void SetPlanet()
    {
        PlanetInfo info = GameManager.Instance.SceneChangeManager.PlanetInfo;
        curExperiment.SetPlanetData(info);

        type = info.Planet;
        environmentView.LoadEnvironment(type);

        statUIController.SetNameText(info.PlanetName);
    }

    private void SetExperiment()
    {
        // 실험들 초기화
        freeFall = new FreeFallExperiment();
        parabola = new ParabolaExperiment(leftStartPos, rightStartPos);
        // TODO - 포물선 운동 힘 세팅하기
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

    private void CreateTarget(Vector3 startPos, int num)
    {
        GameObject target = Instantiate(targets[num]);
        target.GetComponent<TargetView>().SetOriginPos(startPos);

        Rigidbody rb = target.GetComponent<Rigidbody>();

        // 3. 낙하 종단 속도 설정
        TargetType type = (TargetType)num;
        float vt = desiredVt[type];

        float drag = rb.mass * earthGravity.magnitude / vt;
        rb.linearDamping = drag;

        // TODO - 변경에 취약, 따로 bool이나 earth인지 experiment인지를 파라미터로 받는 것도 고려
        if (startPos.x < 0)  // 일단 배치 상 Terrain의 x좌표는 -2000 ~ -3000이라... 지구 Terrain
        {
            // 1. rb useGravity false
            rb.useGravity = false;

            // 2. constForce에 중력 할당.
            ConstantForce con = target.GetComponent<ConstantForce>();
            con.force = earthGravity * rb.mass;
            statUIController.SetTargets(rb, false);
            leftObj = target;
        }
        else
        {
            statUIController.SetTargets(rb, true);
            rightObj = target;
        }
    }

    public void ResetTarget()
    {
        Destroy(leftObj);
        Destroy(rightObj);

        int num = Random.Range(0, 5);
        CreateTarget(selectedTargetPos, num);
        CreateTarget(earthTargetPos, num);
    }
    #endregion

    void Start()
    {
        SetExperiment();
        SelectExperiment(ExperimentType.freeFall);

        int num = Random.Range(0, 5);
        CreateTarget(selectedTargetPos, num);
        CreateTarget(earthTargetPos, num);

        SetPlanet();
    }
}
