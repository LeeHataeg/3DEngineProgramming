using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class PlanetEnvironmentView : MonoBehaviour
{
    [Header("OBJECTS_IN_SCENE")]
    [SerializeField] Renderer[] grounds;

    public void LoadEnvironment(PlanetType type)
    {
        // TODO - LoadScene? In here?
        SetEnvironment(type);
    }


    private async void SetEnvironment(PlanetType type)
    {
        string groundKey = getGroundKey(type);
        string skyboxKey = getSkyboxKey(type);

        Material groundMat = await AddressablesLoader.GetAssets<Material>(groundKey);
        Material skyboxMat = await AddressablesLoader.GetAssets<Material>(skyboxKey);

        Apply(groundMat, skyboxMat);
    }
    private string getGroundKey(PlanetType type)
    {
        return $"Material_Ground_{type}";
    }
    private string getSkyboxKey(PlanetType type)
    {
        return $"Skybox_{type}";
    }
    private void Apply(Material gMat, Material sMat)
    {
        foreach (Renderer ground in grounds)
        {
            ground.material = gMat;
        } 
        RenderSettings.skybox = sMat;
    }
}
