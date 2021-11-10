using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    private int caRuns;
    private int size;
    private int waterLevel;

    private RuleTile groundRuleTile;
    private Tile waterTile;
    
    private Tilemap ground;
    private Tilemap water;

    private MapTile[,] map;

    void Start()
    {
        getResources();
        initMap();
        map = CAMG.generateMap(map, caRuns, waterLevel);
        drawMap();
        GameObject.Find("MapManager").GetComponent<MapManager>().Map = map;
    }

    private void drawMap()
    {
        getResources();
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                if (map[i, j].Value > 0)
                {
                    ground.SetTile(new Vector3Int(i, j, 0), groundRuleTile);
                }
                water.SetTile(new Vector3Int(i, j, 0), waterTile);
            }
        }
    }

    private void getResources()
    {
        MapManager mm = GameObject.Find("MapManager").GetComponent<MapManager>();
        size = mm.MapSize;
        caRuns = mm.CaRuns;
        waterLevel = mm.WaterLevel;
        groundRuleTile = mm.groundRuleTile;
        waterTile = mm.waterTile;
        ground = mm.ground;
        water = mm.water;
    }

    private void initMap()
    {
        for (int i = -1; i <= size; i++) //-1 und <=, damit eine Reihe mehr mit lehren Feldern erstellt wird
        {
            for (int j = -1; j <= size; j++)
            {
                map[i, j] = new MapTile(new Vector2(i, j));
            }
        }

        for (int i = -1; i <= size; i++) //nachträglich Nachbarn vergeben, damit keine Nullreferences
        {
            for (int j = -1; j <= size; j++)
            {
                map[i, j].setNeighbours(MapAnalyzer.getNeighbours(map[i, j]));
            }
        }
    }
}
