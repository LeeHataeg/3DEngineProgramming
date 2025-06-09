using UnityEngine;
using UnityEngine.UI;

public class PlayPauseButtonController : MonoBehaviour
{
    [Header("UI Button Images")]
    [SerializeField] private Button playImage;
    [SerializeField] private Button pauseImage;

    private bool isPlay = true;

    public void OnPlayorPauseClick()
    {
        isPlay = !isPlay;

        if (isPlay)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }

        playImage.gameObject.SetActive(isPlay);
        pauseImage.gameObject.SetActive(!isPlay);
    }
}
