using System;
using UnityEngine;

// 이 스크립트는 포물선 운동 관련 Model 코드
// 따라서 물체 위치 계산 로직 등이 여기 구현되나 물체 조작 등은 Controller, View에서 담당.
public class ParabolaExperiment : BaseExperiment
{
    // temp - target의 변경에 따 라 변경될 필요가 있음. 어캐 적용할지는 몰랑
    private float mass = 1f;
    private float CrossSection = (float)(Math.PI * 0.5 * 0.5);
    private float DragCoefficient = 0.47f; // 물체 특성(대충 그 모양이나 단면적?)에 따른 공기 저항력
    
    private float airDense; // 대기 농도

    private Vector3 gravity;

    // 출발 시 한번 적용되는 외부 힘입니당
    private bool isApplied = false;
    private Vector3 externalForce;

    // 가속도 관련 변수
    private Vector3 changingFactorsInAccel;
    private Vector3 accel;

    // 출력 관련 변수
    private Vector3 velocity = Vector3.zero;
    private Vector3 position = Vector3.zero;
    

    public ParabolaExperiment()
    {
        experimentType = ExperimentType.parabola;
        // temp
        startPos = new Vector3(-9.5f, 0.5f, 0);
    }

    public override void SetPlanetData(PlanetInfo type)
    {
        gravity = new Vector3(0f, type.GravityAccel * (-1), 0f);
        airDense = type.AirDensity;
    }

    public void SetExeternalForce(Vector3 force)
    {
        externalForce = force;
    }
    
    public override Vector3 UpdatePhysics(float deltaTime)
    {
        changingFactorsInAccel = (airDense * DragCoefficient * CrossSection
                            * velocity.magnitude * velocity) / (2f * mass);

        accel = gravity + (-1)* changingFactorsInAccel;

        if (!isApplied)
        {
            accel += (externalForce / mass);
            isApplied = true;
        }

        velocity += accel * deltaTime;

        position += velocity * deltaTime;

        return position;
    }
}
