using UnityEngine;
using UnityEngine.SceneManagement;

public class ExperimentUIController : MonoBehaviour
{
    public void OnPlayClick()
    {
        Time.timeScale = 1f;
    }

    public void OnPauseClick()
    {
        Time.timeScale = 0f;
    }

    public void OnReplayClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
