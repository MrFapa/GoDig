using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map 
{

    private MapTile[,] mapTiles;

    private int size;
    public int Size { get; }

    public Map(int size)
    {
        this.mapTiles = new MapTile[size, size];
        this.size = size;
        initMap();
    }

    public MapTile getTile(Vector2Int pos)
    {
        if(pos.x < 0 || pos.x >= size || pos.y < 0 || pos.y >= size)
        {
            return new MapTile(pos);
        }
        return this.mapTiles[pos.x, pos.y];
    }

    public MapTile getTile(int x, int y)
    {
        return getTile(new Vector2Int(x, y));
    }

    private void initMap()
    {
        for (int i = 0; i < size; i++) 
        {
            for (int j = 0; j < size; j++)
            {
                mapTiles[i, j] = new MapTile(new Vector2Int(i, j));
            }
        }

        for (int i = 0; i < size; i++) 
        {
            for (int j = 0; j < size; j++)
            {
                mapTiles[i, j].setNeighbours(MapAnalyzer.getNeighbours(mapTiles[i, j]));
            }
        }
    }
}
