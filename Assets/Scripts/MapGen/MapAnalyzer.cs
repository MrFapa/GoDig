using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapAnalyzer 
{
    public static Neighbours getNeighbours(MapTile tile)
    {
        MapTile[] neighbours = new MapTile[8];
        int index = 0;

        Map map = GameObject.Find("MapManager").GetComponent<MapManager>().Map;
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if(i == 0 && j == 0)
                {
                    continue;
                }
                neighbours[index] = map.getTile(i, j);
                index++;
            }
        }
        Neighbours obj = new Neighbours();
        obj.setAllNeighbours(neighbours);
        return obj;
    }


   
}
