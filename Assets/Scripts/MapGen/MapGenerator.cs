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
        Debug.Log(Time.realtimeSinceStartup + " | start");
        this.mm = GameObject.Find("MapManager").GetComponent<MapManager>();

        this.map = new Map(mm.MapSize);
        Debug.Log(Time.realtimeSinceStartup + " | map erstellt");
        mm.Map = this.map;
        CellularAutomataMapGenerator.generateMap(ref this.map, mm.CaRuns, mm.WaterLevel);
        Debug.Log(Time.realtimeSinceStartup + " | map generiert");
        this.map.initIslands();
        Debug.Log(Time.realtimeSinceStartup + " | islands erkannt");
        drawMap();
        Debug.Log(Time.realtimeSinceStartup + " | gezeichnet");
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
                    mm.ground.SetTile(new Vector3Int(i, j, 0), mm.groundRuleTile);
                }
                mm.water.SetTile(new Vector3Int(i, j, 0), mm.waterTile);
            }
        }
    }
}
