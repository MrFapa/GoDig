using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LandTypes;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    private MapManager mm;

    private Map map;

    void Start()
    {
        this.mm = GameObject.Find("MapManager").GetComponent<MapManager>();
        this.map = new Map(mm.MapSize);
        CellularAutomataMapGenerator.generateMap(ref this.map, mm.CaRuns, mm.WaterLevel);
        drawMap();
        mm.Map = this.map;
    }

    

    private void drawMap()
    {
        for (int i = 0; i < mm.MapSize; i++)
        {
            for (int j = 0; j < mm.MapSize; j++)
            {
                if (LandValueTypeFunctions.isLandType(this.map.getTile(i, j).LandValue))
                {
                    mm.Ground.SetTile(new Vector3Int(i, j, 0), mm.GroundRuleTile);
                }
                mm.Water.SetTile(new Vector3Int(i, j, 0), mm.WaterTile);
            }
        }
    }
}
