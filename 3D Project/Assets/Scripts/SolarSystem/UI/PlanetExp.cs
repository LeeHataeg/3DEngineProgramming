using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlanetExp : MonoBehaviour
{
    public GameObject descriptionPanel;  // UI 패널
    public TMP_Text descriptionText;     // 설명 표시할 TMP 텍스트
    [TextArea]
    public string description;           // 오브젝트 설명 내용

    void OnMouseEnter()
    {
        descriptionPanel.SetActive(true);
        descriptionText.text = description;
    }

    void OnMouseExit()
    {
        descriptionPanel.SetActive(false);
    }
}