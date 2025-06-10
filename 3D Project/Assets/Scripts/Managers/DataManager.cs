using UnityEngine;

public class DataManager : MonoBehaviour
{
    public PlanetInfoSO PlanetInfoSO;

    private async void Awake()
    {
        PlanetInfoSO = await AddressablesLoader.GetAssets<PlanetInfoSO>(Const.SO_PlanetInfo);
    }
}
