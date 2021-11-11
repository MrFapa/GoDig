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


    private landValueType landValue;
    public landValueType LandValue { get; set; }

    private Map map;
    public MapTile(Vector2Int position, Map map)
    {
        this.map = map;
        this.position = position;
        this.landValue = landValueType.undefined; //default value
    }

    public void updateLandType()
    {
        if(this.landValue == landValueType.water){
            return;
        }else if(LandValueTypeFunctions.isLandType(this.landValue)){
            foreach(NeighbourValueType dir in System.Enum.GetValues(typeof(NeighbourValueType))){
                MapTile neighbourTile = getNeighbour(dir);
                if(neighbourTile.landValue == landValueType.water){
                    this.landValue = landValueType.coast;
                }
            }
        }
    }

    public MapTile getNeighbour(NeighbourValues.NeighbourValueType dir)
    {
        return this.map.getTile(position + NeighbourValues.NeighbourValueTypeFunctions.Offset(dir));
    }

}
