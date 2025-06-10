using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExperimentStatUIController : MonoBehaviour
{

    [Header("Targets (assign in Inspector)")]
    [Tooltip("왼쪽 Target Rigidbody")]
    private Rigidbody leftTargetRb;

    [Tooltip("오른쪽 Target Rigidbody")]
    private Rigidbody rightTargetRb;

    [Header("Controll될 UI들")]
    [SerializeField] private TextMeshProUGUI leftVelocityText;

    [SerializeField] private TextMeshProUGUI rightVelocityText;
    [SerializeField] private TextMeshProUGUI rightPlanetNameText;

    public void SetNameText(string name)
    {
        rightPlanetNameText.text = name;
    }

    public void SetTargets(Rigidbody target, bool isLeft)
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

    void FixedUpdate()
    {
        // 왼쪽 속도 측정
        if (leftTargetRb != null)
            leftVelocityText.text = $"{(leftTargetRb.linearVelocity.magnitude):F2} m/s";

        // 오른쪽 속도 측정
        if (rightTargetRb != null)
            rightVelocityText.text = $"{(rightTargetRb.linearVelocity.magnitude):F2} m/s";
    }
}
