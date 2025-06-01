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
        startPos = new Vector3(0, startY * 3f, 0);
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
    }

    public override Vector3 UpdatePhysics(float time)
    {
        float offset;
        if (airDense <= 0f || float.IsInfinity(vTerm))
        {
            offset = 0.5f * gravityAccel * time * time;
        }
        else
        {
            // 항력 포함 공식: vTerm·vTerm/g * ln(cosh(g·t/vTerm))
            float x = gravityAccel * time / vTerm;
            // (이때 x가 너무 커서 cosh 계산이 오버플로우될 수 있으므로, 필요한 경우 Mathf.Exp 기반으로 안정화 가능)
            offset = vTerm * vTerm / gravityAccel
                      * Mathf.Log((float)Math.Cosh(x));
        }

        //tanhRes = (float)Math.Tanh((gravityAccel * time) / vTerm);
        //offset = vTerm * vTerm / gravityAccel * Mathf.Log((float)Math.Cosh(gravityAccel * time / vTerm));

        return new Vector3(0, offset * (-1), 0);
    }
}
