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

    [Header("Tiles")]
    public RuleTile groundRuleTile;
    public Tile waterTile;


    [Header("Tilemaps")]
    public Tilemap ground;
    public Tilemap water;

    private MapTile[,] map;
    public MapTile[,] Map
    {
        get { return map; }
        set { map = value; }
    }
}
