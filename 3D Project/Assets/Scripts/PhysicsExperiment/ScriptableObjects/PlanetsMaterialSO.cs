using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

[System.Serializable]
public class PlanetMeterials
{
    public PlanetType Planet;
    public Material Ground;
    public Material Skybox;
}

[CreateAssetMenu(fileName = "PlanetsMaterialSO", menuName = "Scriptable Objects/PlanetsMaterialSO")]
public class PlanetsMaterialSO : ScriptableObject
{
    public List<PlanetMeterials> planetValues;

    private Dictionary<PlanetType, PlanetMeterials> planetDictionary;

    public void Init()
    {
        planetDictionary = planetValues.ToDictionary(p => p.Planet);
    }

    public Material GetGround(PlanetType planet) => planetDictionary[planet].Ground;
    public Material GetSkybox(PlanetType planet) => planetDictionary[planet].Skybox;
}
