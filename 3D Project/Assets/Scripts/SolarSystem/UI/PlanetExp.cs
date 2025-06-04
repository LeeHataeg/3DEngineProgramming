using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlanetExp : MonoBehaviour
{
    public GameObject descriptionPanel;  // UI 패널
    public TMP_Text descriptionText;     // 설명 표시할 TMP 텍스트
    [TextArea]
    private string description;           // 오브젝트 설명 내용

    private void Start()
    {
        description = "수성에는 대기가 거의 존재하지 않고 매우 가벼운 가스층이 있습니다. \n" +
            "수성의 지형은 달의 지형과 비슷합니다. \n" +
            "수성의 자전과 공전은 3:2의 비율입니다. 즉 태양의 주위를 2번 공전할 동안 3번 자전하는 겁니다.";
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
}
