using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LandTypes;
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
    public LandValueType LandValue { get; set; }

    private Map map;
    public MapTile(Vector2Int position, Map map)
    {
        this.map = map;
        this.position = position;
        this.landValue = LandValueType.undefined; //default value
    }

    public void updateLandType()
    {
        if (this.landValue == LandValueType.water)
        {
            return;
        }
        else if (LandValueTypeFunctions.isLandType(this.landValue))
        {
            foreach (NeighbourValueType dir in System.Enum.GetValues(typeof(NeighbourValueType)))
            {
                MapTile neighbourTile = getNeighbour(dir);
                if (neighbourTile.landValue == LandValueType.water)
                {
                    this.landValue = LandValueType.coast;
                }
            }
        }
    }

    public MapTile getNeighbour(NeighbourValues.NeighbourValueType dir)
    {
        return this.map.getTile(position + NeighbourValues.NeighbourValueTypeFunctions.Offset(dir));
    }

}
