using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LandTypes;
using LandTopping;
using NeighbourValues;

public class MapTile
{
    private Vector2Int position;
    public Vector2Int Position
    {
        get { return position; }
        set { position = value; }
    }


    private LandValueType landValue;
    public LandValueType LandValue
    {
        get { return landValue; } //land, coast, water, ...
        set { landValue = value; }
    }

    private LandToppingTypes landTopping;
    public LandToppingTypes LandTopping
    {
        get { return landTopping; }
        set { landTopping = value; }
    }

    private Map map;
    private Island island;

    public MapTile(Vector2Int position, Map map)
    {
        this.map = map;
        this.position = position;
        this.landValue = LandValueType.undefined; //default value
        this.landTopping = LandToppingTypes.undefined;
    }

    public void updateLandType()
    {
        if (this.landValue == LandValueType.water)
        {
            return;
        }
        else if (LandValueTypeFunctions.isLandType(this.landValue))
        {
            foreach (NeighbourValueType dir in System.Enum.GetValues(typeof(NeighbourValueType))) //todo, check adjacent neigbours only
            {
                if (NeighbourValueTypeFunctions.isAdjacentneighbour(dir))
                {
                    MapTile neighbourTile = getNeighbour(dir);
                    if (neighbourTile.landValue == LandValueType.water)
                    {
                        this.landValue = LandValueType.coast;
                    }
                }
            }
        }
    }

    public MapTile getNeighbour(NeighbourValues.NeighbourValueType dir)
    {
        return this.map.getTile(position + NeighbourValues.NeighbourValueTypeFunctions.Offset(dir));
    }

    public MapTile getAdjacentNeighbour(NeighbourValues.NeighbourValueType dir)
    {
        return this.map.getTile(position + NeighbourValues.NeighbourValueTypeFunctions.AdjacentNeighbours(dir));
    }

    public void setIsland(Island island)
    {
        this.island = island;
    }

    public Island getIsland()
    {
        return this.island;
    }

}
