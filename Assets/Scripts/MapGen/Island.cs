using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Island
{
    private ArrayList tiles;

    private Vector2Int centerPoint;
    public Vector2Int CenterPoint
    {
        get { return getCenterPoint(); }
    }

    public Island(ArrayList associatedTiles)
    {
        this.tiles = associatedTiles;
        this.centerPoint = Vector2Int.zero;
    }

    public Island()
        : this(new ArrayList())
    {

    }

    public void addTile(MapTile tile)
    {
        this.tiles.Add(tile);
        this.centerPoint = Vector2Int.zero;
    }

    public void removeTile(MapTile tile)
    {
        if (this.tiles.Contains(tile))
        {
            this.tiles.Remove(tile);
            this.centerPoint = Vector2Int.zero;
        }
    }

    private Vector2Int getCenterPoint()
    {
        if (this.centerPoint == Vector2Int.zero)
        {
            int coastTiles = 0;
            foreach (MapTile tile in tiles)
            {
                if (tile.LandValue == LandTypes.LandValueType.coast)
                {
                    this.centerPoint += tile.Position;
                    coastTiles++;
                }
            }
            this.centerPoint = this.centerPoint / coastTiles;            
        }
        return this.centerPoint;
    }
}
