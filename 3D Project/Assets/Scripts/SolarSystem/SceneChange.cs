using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private string sceneToLoad = "PhyscisScene"; // 이동할 씬 이름

    void OnMouseDown()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
