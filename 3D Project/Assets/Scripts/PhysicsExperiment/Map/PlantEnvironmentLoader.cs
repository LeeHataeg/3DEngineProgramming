using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class PlantEnvironmentLoader : MonoBehaviour
{
    // facade : ���⼭ ���ุ -> ���� �ý��ۿ��� ����

    // TODO - button -> Input - PlanetType
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

        Apply();
    }
    private string getGroundKey(PlanetType type)
    {
        return $"Material_Ground_{type}";
    }
    private string getSkyboxKey(PlanetType type)
    {
        return $"Skybox_{type}";
    }
    private void Apply()
    {
        // TODO : FUCK U
    }
}
