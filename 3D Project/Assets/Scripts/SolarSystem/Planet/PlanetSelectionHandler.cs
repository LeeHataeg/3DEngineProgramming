using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetSelectionHandler : MonoBehaviour
{
    public PlanetType planetType;

    void OnMouseDown()
    {
        GameManager.Instance.SceneChangeManager.SetPhysicsScene(GameManager.Instance.DataManager.
            PlanetInfoSO.GetPlanetInfo(planetType));
        Time.timeScale = 1f;
    }
}
