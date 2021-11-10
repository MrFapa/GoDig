using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LandTypes;

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

    private Neighbours neighbours;

    public MapTile(Vector2Int position)
    {
        this.position = position;
        this.neighbours = new Neighbours();
        this.landValue = landValueType.undefined; //default value
    }

    public void updateLandType()
    {
        if (neighbours != null)
        {
            if (this.landValue == landValueType.land || this.landValue == landValueType.coast)
            {
                foreach (int allignedNeighbour in this.neighbours.allignedNeighbours())
                {
                    if (this.neighbours.allNeighbours[allignedNeighbour].landValue == landValueType.water)
                    {
                        this.landValue = landValueType.coast;
                        return;
                    }
                }
                this.landValue = landValueType.land;
                return;
            } else
            {
                this.landValue = landValueType.water;
            }
        }
    }

    public void setNeighbours(Neighbours neighbours)
    {
        this.neighbours = neighbours;
    }

    public Neighbours getNeighbours()
    {
        return this.neighbours;
    }
}
