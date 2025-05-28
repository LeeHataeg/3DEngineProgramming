using UnityEngine;
using UnityEngine.UI;

public class TimeControl : MonoBehaviour
{
    public Button slowButton;        
    public Button fastButton;        

    public GameObject playButton;    
    public GameObject stopButton;  

    private bool isPaused = false;

    void Start()
    {
        slowButton.onClick.AddListener(SlowDownTime);
        fastButton.onClick.AddListener(SpeedUpTime);

        // 버튼 클릭 이벤트 연결 (두 이미지 버튼 모두 같은 함수 사용)
        playButton.GetComponent<Button>().onClick.AddListener(TogglePausePlay);
        stopButton.GetComponent<Button>().onClick.AddListener(TogglePausePlay);

        SetPauseState(false); // 시작 시 재생 상태
    }

    void SlowDownTime()
    {
        if (!isPaused)
            Time.timeScale = Mathf.Max(Time.timeScale / 2f, 0.1f);
    }

    void SpeedUpTime()
    {
        if (!isPaused)
            Time.timeScale = Mathf.Min(Time.timeScale * 2f, 10f);
    }

    void TogglePausePlay()
    {
        SetPauseState(!isPaused);
    }

    void SetPauseState(bool pause)
    {
        isPaused = pause;
        Time.timeScale = pause ? 0f : 1f;

        playButton.SetActive(!pause); 
        stopButton.SetActive(pause);  
    }
}
