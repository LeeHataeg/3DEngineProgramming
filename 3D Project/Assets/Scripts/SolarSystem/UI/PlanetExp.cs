using UnityEngine;
using TMPro;

public class PlanetExp : MonoBehaviour
{
    public RectTransform descriptionPanel;     // UI Panel (Canvas 안에 있는 RectTransform)
    public TMP_Text descriptionText;           // 텍스트 내용
    [TextArea]
    public string description;

    public Vector3 offset = new Vector3(30f, -145f, 0f); // UI 위치 보정값 (픽셀 단위)

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        descriptionPanel.gameObject.SetActive(false);
    }

    void OnMouseEnter()
    {
        descriptionPanel.gameObject.SetActive(true);
        descriptionText.text = description;
    }

    void OnMouseExit()
    {
        descriptionPanel.gameObject.SetActive(false);
    }

    void Update()
    {
        if (descriptionPanel.gameObject.activeSelf)
        {
            // 행성의 월드 위치를 화면 좌표로 변환
            Vector3 screenPos = mainCamera.WorldToScreenPoint(transform.position);

            // 오프셋 적용 후 UI 위치 지정
            descriptionPanel.position = screenPos + offset;
        }
    }
}
