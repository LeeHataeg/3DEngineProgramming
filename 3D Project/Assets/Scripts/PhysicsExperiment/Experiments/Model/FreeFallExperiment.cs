using System;
using Unity.VisualScripting;
using UnityEngine;

public class FreeFallExperiment : BaseExperiment
{
    // Target관련 Model에서 질량과 단면적 항력 계수를 받아옴
    //  일단 Sphere로 가정하고 진행(차후 물체를 추가하며 작성하도록)
    // Controller에서 행성 중력 가속도, 대기 밀도를 받아옴.
    float mass = 1f;
    float CrossSection = (float)(Math.PI * 0.5 * 0.5);
    float DragCoefficient = 0.47f; // 물체 특성에 따른 공기 저항력

    float gravityAccel;
    float airDense;

    float vTerm;
    float tanhRes;
    float velocity;

    public void SetPlanetData(PlanetInfo info)
    {
        gravityAccel = info.GravityAccel;
        airDense = info.AirDensity;
    }

    public override void UpdatePhysics(float dt)
    {
        velocity = GetVelocity(dt);

    }

    private float GetVelocity(double time)
    {
        vTerm = (float)Math.Sqrt((2 * mass * gravityAccel) / (airDense * DragCoefficient * CrossSection));\
        tanhRes = (float)Math.Tanh(time);

        return vTerm * tanhRes;
    }
}
