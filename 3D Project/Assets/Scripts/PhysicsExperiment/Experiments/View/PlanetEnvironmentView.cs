using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class PlanetEnvironmentView : MonoBehaviour
{
    [Header("OBJECTS_IN_SCENE")]
    [SerializeField] Renderer[] grounds;

    public void LoadEnvironment(PlanetType type)
    {
        SetEnvironment(type);
    }


    private async void SetEnvironment(PlanetType type)
    {
        string skyboxKey = getSkyboxKey(type);
        Material skyboxMat = await AddressablesLoader.GetAssets<Material>(skyboxKey);
        RenderSettings.skybox = skyboxMat;

        GameObject ground = await AddressablesLoader.GetAssets<GameObject>(Const.Prefabs_PhysicsGround);
        Instantiate(ground);
    }
    private string getSkyboxKey(PlanetType type)
    {
        return $"Skybox_{type}";
    }
}
