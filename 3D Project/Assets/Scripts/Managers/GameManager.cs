using Unity.VisualScripting;
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

        Init();
    }

    private void Init()
    {
        if(DataManager == null)
            DataManager = gameObject.AddComponent<DataManager>();

        if (SceneChangeManager == null)
            SceneChangeManager = gameObject.AddComponent<SceneChangeManager>();
    }
}