using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile 
{
    private Vector2 position;
    public Vector2 Position
    {
        get { return position; }
        set { position = value; }
    }

    private int landValue;
    public int Value { get { return landValue; } set { landValue = value; } }

    private bool isCoast;
    private Neighbours neighbours;

    public MapTile(Vector2 position)
    {
        this.position = position;
        this.neighbours = new Neighbours();
        this.landValue = -1; //default value
    }

    public bool checkCoast()
    {
        if(neighbours != null)
        {
            if(this.landValue == 1)
            {
                for(int i = 1; i == 7; i += 2)
                {
                    if(this.neighbours.allNeighbours[i].Value == 0)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public void setNeighbours(MapTile[] neighbours)
    {
        this.neighbours.setAllNeighbours(neighbours);
    }

    public Neighbours getNeighbours()
    {
        return this.neighbours;
    }
}
