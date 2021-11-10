using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class WalkalbeCalculator 
{
    public static bool[,] calculateWalkable()
    {
        Tilemap ground = GameObject.Find("MapManager").GetComponent<MapManager>().Ground;
        int size = GameObject.Find("MapManager").GetComponent<MapManager>().MapSize;

        bool[,] walkable = new bool[size, size];
        for (int x = 0; x < walkable.GetLength(0); x++)
        {
            for (int y = 0; y < walkable.GetLength(1); y++)
            {
                walkable[x, y] = ground.GetTile(new Vector3Int(x, y, 0)) != null;
            }
        }

        return walkable;
    }

    
    
}
