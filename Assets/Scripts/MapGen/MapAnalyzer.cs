using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapAnalyzer 
{
    public static MapTile[] getNeighbours(MapTile tile)
    {
        MapTile[] neighbours = new MapTile[8];
        int index = 0;

        MapTile[,] map = GameObject.Find("MapManager").GetComponent<MapManager>().Map;
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                neighbours[index] = map[(int)tile.Position.x, (int)tile.Position.y];
                index++;
            }
        }

        return neighbours;
    }


   
}
