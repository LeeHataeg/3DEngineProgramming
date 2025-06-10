using System;
using Unity.VisualScripting;
using UnityEngine;

public class FreeFallExperiment : BaseExperiment
{
    // 자유 낙하 운동
    // Target관련 Model에서 질량과 단면적 항력 계수를 받아옴
    //  일단 Sphere로 가정하고 진행(차후 물체를 추가하며 작성하도록)
    // Controller에서 행성 중력 가속도, 대기 밀도를 받아옴.=-

    // temp - target의 변경에 따라 변경될 필요가 있음.
    private float mass = 1f;
    private float CrossSection = (float)(Math.PI * 0.5 * 0.5);
    private float DragCoefficient = 0.47f; // 물체 특성에 따른 공기 저항력

    private float startY = 6f;

    private float gravityAccel;
    private float airDense;

    private float vTerm; // 종단 속도
    private float tanhRes;

    public FreeFallExperiment()
    {
        experimentType = ExperimentType.freeFall;
    }

    public override void SetPlanetData(PlanetInfo type)
    {
        gravityAccel = type.GravityAccel;
        airDense = type.AirDensity;

        if (airDense <= 0f)
        {
            vTerm = float.PositiveInfinity;
        }
        else
        {
            vTerm = Mathf.Sqrt((2f * mass * gravityAccel)
                               / (airDense * DragCoefficient * CrossSection));
        }

        Physics.gravity = new Vector3(0, -1 * type.GravityAccel, 0);
    }
}
