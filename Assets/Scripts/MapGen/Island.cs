using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Island
{
    private ArrayList tiles;
    private ArrayList coastTiles;

    private Vector2Int centerPoint;
    public Vector2Int CenterPoint
    {
        get { return getCenterPoint(); }
    }
    public int Size
    {
        get { return calcSize(); }
    }

    public Island(ArrayList associatedTiles)
    {
        this.tiles = associatedTiles;
        this.coastTiles = new ArrayList();
        this.centerPoint = Vector2Int.zero;
        initCoastTiles();
    }

    public Island()
        : this(new ArrayList())
    {

    }

    public void addTile(MapTile tile)
    {
        this.tiles.Add(tile);
        this.centerPoint = Vector2Int.zero;
        initCoastTiles();
    }

    public void removeTile(MapTile tile)
    {
        if (this.tiles.Contains(tile))
        {
            this.tiles.Remove(tile);
            this.centerPoint = Vector2Int.zero;
            initCoastTiles();
        }
    }

    public bool contains(MapTile tile)
    {
        return this.tiles.Contains(tile);
    }

    public MapTile nearestMapTileToCoord(Vector2Int cord)
    {
        MapTile closestTile = new MapTile(new Vector2Int(0, 0), new Map(0));
        float lowestDst = -1;
        foreach (MapTile tile in tiles)
        {
            float dst = (tile.Position - cord).magnitude;
            if (dst < lowestDst)
            {
                closestTile = tile;
                lowestDst = dst;
            }
        }
        return closestTile;
    }
    public MapTile nearestCoastTileToCoord(Vector2Int cord)
    {
        MapTile closestTile = new MapTile(new Vector2Int(0, 0), new Map(0));
        float lowestDst = 100;
        foreach (MapTile tile in coastTiles)
        {
            float dst = (tile.Position - cord).magnitude;
            if (dst < lowestDst)
            {
                closestTile = tile;
                lowestDst = dst;
            }
        }
        return closestTile;
    }

    private Vector2Int getCenterPoint()
    {
        if (this.centerPoint == Vector2Int.zero)
        {
            foreach (MapTile tile in this.coastTiles)
            {
                this.centerPoint += tile.Position;
            }
            this.centerPoint = this.centerPoint / this.coastTiles.Count;
        }
        return this.centerPoint;
    }

    private void initCoastTiles()
    {
        foreach (MapTile tile in tiles)
        {
            if (tile.LandValue == LandTypes.LandValueType.coast)
            {
                this.coastTiles.Add(tile);
            }
        }
    }

    private int calcSize()
    {
        int size = 0;
        foreach (MapTile tile in tiles)
        {
            if (tile.LandValue != LandTypes.LandValueType.undefined)
            {
                size++;
            }
        }
        return size;
    }
}
