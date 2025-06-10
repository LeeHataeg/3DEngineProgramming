using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExperimentUIController : MonoBehaviour
{
    [SerializeField] ExperimentController con;

    #region Buttons
    public void OnStopClick()
    {
        Time.timeScale = 0f;
        con.ResetTarget();
    }

    public void OnReplayClick()
    {
        con.ResetTarget();
        Time.timeScale = 1f;
    }

    public void OnExitClick()
    {
        GameManager.Instance.SceneChangeManager.SetMainScene();
        Time.timeScale = 1f;
    }

    public void OnChangePhysics()
    {
        //
    }
    #endregion
}
