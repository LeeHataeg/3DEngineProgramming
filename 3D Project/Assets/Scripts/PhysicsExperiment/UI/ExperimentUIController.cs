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

    public void OnStopClick()
    {
        Time.timeScale = 0f;
        GameManager.Instance.SceneChangeManager.SetPhysicsScene();
    }
    public void OnReplayClick()
    {
        GameManager.Instance.SceneChangeManager.SetPhysicsScene();
        Time.timeScale = 1f;
    }

    public void OnExitClick()
    {
        GameManager.Instance.SceneChangeManager.SetMainScene();
        Time.timeScale = 1f;
    }
}
