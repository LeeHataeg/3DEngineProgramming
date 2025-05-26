using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum PlanetType
{
    Mercury,
    Venus,
    Earth,
    Mars,
    Jupiter,
    Saturn,
    Uranus,
    Neptune,
    Others
}

[System.Serializable]
public class PlanetInfo
{
    public PlanetType Planet;
    public string PlanetName;   // ? �ѱ� �̸�?

    // For Rotate
    public double distance; // From Sundd
    public float AirPressure;

    // For Experiment
    public float GravityAccel;
    public float AirDensity;
}
[CreateAssetMenu(fileName = "PlanetPhysicalInfoSO", menuName = "Scriptable Objects/PlanetPhysicalInfoSO")]
public class PlanetInfoSO : ScriptableObject
{
    public List<PlanetInfo> planetValues;

    private Dictionary<PlanetType, PlanetInfo> planetDictionary;

    private void OnEnable()
    {
        Init();
    }

    public void Init()
    {
        if (planetValues == null || planetValues.Count == 0)
        {
            return;
        }
        planetDictionary = planetValues.ToDictionary(p => p.Planet);
    }

    public PlanetInfo GetPlanetInfo(PlanetType planet)
    {
        if (planetDictionary == null)
            Init();

        return planetDictionary[planet];
    }
}
