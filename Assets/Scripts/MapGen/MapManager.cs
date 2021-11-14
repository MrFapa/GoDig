using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    [Header("Map Attributes")]
    [SerializeField]
    private int mapSize;
    public int MapSize { get { return mapSize; } }

    [SerializeField]
    private int caRuns;
    public int CaRuns { get { return caRuns; } }

    [SerializeField]
    [Range(430, 520)]
    private int waterLevel;
    public int WaterLevel { get { return waterLevel; } }
    [SerializeField]
    [Range(0, 100)]
    private int vegetationLevel;
    public int VegetationLevel
    {
        get { return vegetationLevel; }
    }

    [SerializeField]
    private int bridgeThreshold;
    public int BridgeThreshold
    {
        get { return bridgeThreshold; }
    }

    [Header("Tiles")]
    public RuleTile groundRuleTile;
    public Tile waterTile;
    public RuleTile bridgeRuleTile;
    public RandomTile vegetationRandomTile;


    [Header("Tilemaps")]
    public Tilemap ground;
    public Tilemap water;
    public Tilemap bridge;
    public Tilemap vegetation;

    private Map map;
    public Map Map
    {
        get { return map; }
        set { map = value; }
    }
}
