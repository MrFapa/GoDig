using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LandTypes;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    private MapManager mm;

    private Map map;

    public void InitMap()
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
    }

    public void addBridge()
    {
        Island a = map.getIsland(0);

        int r = Random.Range(1, map.islandCount());
        Island b = map.getIsland(r);

        BridgeBuilder.findBridgePath(a, b);
    }


    public void drawMap()
    {
        for (int i = 0; i < mm.MapSize; i++)
        {
            for (int j = 0; j < mm.MapSize; j++)
            {
                if (LandValueTypeFunctions.isLandType(this.map.getTile(i, j).LandValue))
                {
                    mm.ground.SetTile(new Vector3Int(i, j, 0), mm.groundRuleTile);

                    if (Random.Range(0, 100) < mm.VegetationLevel)
                    {
                        Debug.Log("Sup");
                        mm.vegetation.SetTile(new Vector3Int(i, j, 0), mm.vegetationRandomTile);
                    }
                }

                if (LandValueType.bridge == this.map.getTile(i, j).LandValue)
                {
                    mm.bridge.SetTile(new Vector3Int(i, j, 0), mm.bridgeRuleTile);
                }

                mm.water.SetTile(new Vector3Int(i, j, 0), mm.waterTile);
            }
        }
    }
}
