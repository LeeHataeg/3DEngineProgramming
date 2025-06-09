using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExperimentUIController : MonoBehaviour
{
    #region Buttons
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
    #endregion
}
