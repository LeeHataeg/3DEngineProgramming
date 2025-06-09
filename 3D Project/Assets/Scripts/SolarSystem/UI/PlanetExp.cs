using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlanetExp : MonoBehaviour
{
    public GameObject descriptionPanel;   // UI 패널 (Canvas 안에 있어야 함)
    public TMP_Text descriptionText;      // 설명 텍스트
    [TextArea]
    public string description;            // 설명 내용

    public Vector3 offset = new Vector3(0, -50f, 0); // 행성 아래로 내리는 위치 보정
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void OnMouseEnter()
    {
        descriptionPanel.SetActive(true);
        descriptionText.text = description;
    }

    void OnMouseExit()
    {
        descriptionPanel.SetActive(false);
    }

    void Update()
    {
        if (descriptionPanel.activeSelf)
        {
            // 1. 행성의 위치를 화면 좌표로 변환
            Vector3 screenPos = mainCamera.WorldToScreenPoint(transform.position);
            screenPos += offset;

            // 2. 화면 범위를 벗어나지 않도록 제한
            screenPos.x = Mathf.Clamp(screenPos.x, 0, Screen.width - 150);  // 패널 너비 고려
            screenPos.y = Mathf.Clamp(screenPos.y, 0, Screen.height - 50); // 패널 높이 고려

            // 3. 패널 위치 지정
            descriptionPanel.transform.position = screenPos;
        }
    }
}
