using System;
using Unity.VisualScripting;
using UnityEngine;

public class FreeFallExperiment : BaseExperiment
{
    // Target관련 Model에서 질량과 단면적 항력 계수를 받아옴
    //  일단 Sphere로 가정하고 진행(차후 물체를 추가하며 작성하도록)
    // Controller에서 행성 중력 가속도, 대기 밀도를 받아옴.=-

    float mass = 1f;
    float CrossSection = (float)(Math.PI * 0.5 * 0.5);
    float DragCoefficient = 0.47f; // 물체 특성에 따른 공기 저항력

    float gravityAccel;
    float airDense;

    float vTerm; // 종단 속도
    float tanhRes;

    public FreeFallExperiment()
    {
        experimentType = ExperimentType.freeFall;
    }

    public override void SetPlanetData(PlanetInfo type)
    {
        gravityAccel = type.GravityAccel;
        airDense = type.AirDensity;
        vTerm = Mathf.Sqrt((2f * mass * gravityAccel) / (airDense * DragCoefficient * CrossSection));

    }

    public override Vector3 UpdatePhysics(float time)
    {
        float offset;
        Vector3 vec;

        tanhRes = (float)Math.Tanh((gravityAccel * time) / vTerm);
        offset = vTerm * vTerm / gravityAccel * Mathf.Log((float)Math.Cosh(gravityAccel * time / vTerm));

        vec = new Vector3(0, offset * (-1), 0);

        return vec;
    }
}
