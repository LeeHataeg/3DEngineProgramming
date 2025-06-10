using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    private PlanetInfo planetInfo = null;

    public PlanetInfo PlanetInfo => planetInfo;

    public void SetPhysicsScene()
    {
        //Default Setting
        planetInfo = GameManager.Instance.DataManager.PlanetInfoSO.GetPlanetInfo(PlanetType.Mercury);

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
