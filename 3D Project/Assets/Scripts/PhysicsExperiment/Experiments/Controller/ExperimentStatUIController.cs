using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExperimentStatUIController : MonoBehaviour
{

    [Header("Targets (assign in Inspector)")]
    [Tooltip("왼쪽 Rigidbody")]
    private Rigidbody leftTargetRb;

    [Tooltip("오른쪽 Rigidbody")]
    private Rigidbody rightTargetRb;

    [Header("UI Elements (assign in Inspector)")]
    [SerializeField] private TextMeshProUGUI leftVelocityText;        // TMPro ��� �� TextMeshProUGUI
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
            leftVelocityText.text = $"{Mathf.Abs(leftTargetRb.linearVelocity.y):F2} m/s";

        // 오른쪽 속도 측정
        if (rightTargetRb != null)
            rightVelocityText.text = $"{Mathf.Abs(rightTargetRb.linearVelocity.magnitude):F2} m/s";
    }
}
