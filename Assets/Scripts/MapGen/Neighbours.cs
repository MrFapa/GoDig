using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbours
{
    public MapTile[] allNeighbours;

    public MapTile topLeft;
    public MapTile topMiddle;
    public MapTile topRight;
    public MapTile middleLeft;
    public MapTile middleRight;
    public MapTile bottomLeft;
    public MapTile bottomMiddle;
    public MapTile bottomRight;

    void specifyNeighbours()
    {
        topLeft = this.allNeighbours[0];
        topMiddle = this.allNeighbours[1];
        topRight = this.allNeighbours[2];
        middleLeft = this.allNeighbours[3];
        middleRight = this.allNeighbours[4];
        bottomLeft = this.allNeighbours[5];
        bottomMiddle = this.allNeighbours[6];
        bottomRight = this.allNeighbours[7];
    }

    public void setAllNeighbours(MapTile[] neighbours)
    {
        this.allNeighbours = neighbours;
        specifyNeighbours();
    }
}
