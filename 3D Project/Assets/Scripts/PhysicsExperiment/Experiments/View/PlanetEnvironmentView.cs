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
            if (ground != null)
            {
                ground.material = gMat;
            }
        } 
        RenderSettings.skybox = sMat;
    }

    private void Awake()
    {
        // 혹시라도 안 채워졌으면 동적으로 찾기
        if (grounds == null || grounds.Length == 0)
        {
            GameObject groundsPar = Instantiate(Resources.Load<GameObject>(Const.Prefabs_PhysicsGround));
            grounds = groundsPar.GetComponentsInChildren<Renderer>();
        }
    }
}
