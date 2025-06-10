using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExperimentStatUIController : MonoBehaviour
{
    private Rigidbody leftTargetRb;
    private Rigidbody rightTargetRb;

    [Header("Controll될 UI들")]
    [SerializeField] private TextMeshProUGUI leftVelocityText;

    [SerializeField] private TextMeshProUGUI rightVelocityText;
    [SerializeField] private TextMeshProUGUI rightPlanetNameText;

    public void SetNameText(string name)
    {
        rightPlanetNameText.text = name;
    }

    public void SetTargetsRigidbody(Rigidbody target, bool isLeft)
    {
        if (isLeft)
        {
            leftTargetRb = target;
        }
        else
        {
            rightTargetRb = target;
        }

    }
    float logInterval = 0.3f;
    private float logTimer = 0f;
    void FixedUpdate()
    {
        //// 왼쪽 속도 측정
        //if (leftTargetRb != null)
            leftVelocityText.text = $"{(leftTargetRb.linearVelocity.magnitude):F2} m/s";

        //// 오른쪽 속도 측정
        //if (rightTargetRb != null)
            rightVelocityText.text = $"{(rightTargetRb.linearVelocity.magnitude):F2} m/s";

        Debug.Log($"[{Time.fixedTime:F2}s] RB: {leftTargetRb.linearVelocity}");
        Debug.Log($"[{Time.fixedTime:F2}s] 속도: {leftTargetRb.linearVelocity.magnitude}");
        Debug.Log("===============");
    }
}
