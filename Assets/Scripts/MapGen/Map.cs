using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NeighbourValues;
using LandTypes;

public class Map
{

    private MapTile[,] mapTiles;
    private ArrayList islands;

    private int size;
    public int Size { get { return size; } }

    public Map(int size)
    {
        this.mapTiles = new MapTile[size, size];
        this.size = size;
        initTiles();
    }

    public void initIslands()
    {
        ArrayList assignedTiles = new ArrayList();
        ArrayList unassignedTiles = new ArrayList();
        ArrayList islands = new ArrayList();

        unassignedTiles.AddRange(this.getMapTiles(new[] { LandTypes.LandValueType.land, LandTypes.LandValueType.coast }));

        //foreach (MapTile tile in unassignedTiles)
        while (unassignedTiles.Count > 0)
        {
            MapTile tile = (MapTile)unassignedTiles[0];
            if (assignedTiles.Contains(tile))
            {
                unassignedTiles.RemoveAt(0);
                continue;
            }
            else
            {
                ArrayList newIslandTileList = new ArrayList();
                Stack tilesToCheck = new Stack();
                tilesToCheck.Push(tile);
                while (tilesToCheck.Count > 0)
                {
                    MapTile currentTile = (MapTile)tilesToCheck.Pop();
                    newIslandTileList.Add(currentTile);
                    unassignedTiles.Remove(currentTile);
                    assignedTiles.Add(currentTile);
                    foreach (NeighbourValueType dir in System.Enum.GetValues(typeof(NeighbourValueType)))
                    {
                        MapTile Neighbour = currentTile.getNeighbour(dir);
                        if (LandValueTypeFunctions.isLandType(Neighbour.LandValue) && (!newIslandTileList.Contains(Neighbour)))
                        {
                            tilesToCheck.Push(Neighbour);
                        }
                    }
                }
                Island newIsland = new Island(newIslandTileList);
                islands.Add(newIsland);
            }
        }
        Debug.Log(islands.Count);
    }

    private void initTiles()
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                mapTiles[i, j] = new MapTile(new Vector2Int(i, j), this);
            }
        }
    }



    public MapTile getTile(Vector2Int pos)
    {
        if (pos.x < 0 || pos.x >= size || pos.y < 0 || pos.y >= size)
        {
            var Result = new MapTile(pos, null);
            Result.LandValue = LandTypes.LandValueType.undefined;
            return Result;
        }
        return this.mapTiles[pos.x, pos.y];
    }

    public MapTile getTile(int x, int y)
    {
        return getTile(new Vector2Int(x, y));
    }

    public ArrayList getMapTiles(LandTypes.LandValueType[] givenLandTypes)
    {
        ArrayList tiles = new ArrayList();

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (System.Array.Exists(givenLandTypes, landtype => (landtype == this.mapTiles[i, j].LandValue)))
                {
                    tiles.Add(this.mapTiles[i, j]);
                }
            }
        }
        return tiles;
    }

}
