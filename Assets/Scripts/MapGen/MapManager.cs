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
    private RuleTile groundRuleTile;
    public RuleTile GroundRuleTile { get { return groundRuleTile; } }
    private Tile waterTile;
    public Tile WaterTile { get { return waterTile; } }


    [Header("Tilemaps")]
    private Tilemap ground;
    public Tilemap Ground { get { return ground; } }
    private Tilemap water;
    public Tilemap Water { get { return water; } }

    private Map map;
    public Map Map
    {
        get { return map; }
        set { map = value; }
    }
}
