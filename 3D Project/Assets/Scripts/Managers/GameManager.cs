using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private volatile static GameManager instance;

    public DataManager DataManager;
    public SceneChangeManager SceneChangeManager;

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }


}

[System.Serializable]
public class DataManager
{
    public PlanetInfoSO PlanetInfoSO;
}

[System.Serializable]
public class SceneChangeManager
{
    private PlanetInfo planetInfo = null;

    public PlanetInfo PlanetInfo => planetInfo;

    public void SetPhysicsScene()
    {
        SceneManager.LoadScene(Const.PhysicsScene);
    }

    public void SetPhysicsScene(PlanetInfo info)
    {
        planetInfo = info;
        SceneManager.LoadScene(Const.PhysicsScene);
    }

    public void SetMainScene()
    {
        planetInfo = null;
        SceneManager.LoadScene(Const.MainScene);
    }
}