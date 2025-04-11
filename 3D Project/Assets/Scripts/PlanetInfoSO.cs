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
    public string PlanetName;

    public double distance; // From Sun

    public float Gravity;
    public float AirPressure;
    public float AirDensity;
}
[CreateAssetMenu(fileName = "PlanetPhysicalInfoSO", menuName = "Scriptable Objects/PlanetPhysicalInfoSO")]
public class PlanetInfoSO : ScriptableObject
{
    public List<PlanetInfo> planetValues;

    private Dictionary<PlanetType, PlanetInfo> planetDictionary;

    public void Init()
    {
        planetDictionary = planetValues.ToDictionary(p => p.Planet);
    }

    public PlanetInfo GetPlanetInfo(PlanetType planet) => planetDictionary[planet];
}
