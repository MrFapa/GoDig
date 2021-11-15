using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge
{
    private Island island1;
    private Island island2;
    private MapTile startTile;
    private MapTile endTile;
    private ArrayList bridgePath;

    public Bridge(Island i1, Island i2)
    {
        this.island1 = i1;
        this.island2 = i2;

        initBridgePath();
    }

    private void initBridgePath()
    {
        Vector2Int averageCenter = (this.island1.CenterPoint + this.island2.CenterPoint) / 2;
        this.startTile = island1.nearestCoastTileToCoord(averageCenter);
        this.endTile = island2.nearestCoastTileToCoord(averageCenter);

        this.bridgePath = BridgeBuilder.findBridgePath(this.startTile, this.endTile);
    }

    private void calcBridgePath()
    {
        this.bridgePath = BridgeBuilder.findBridgePath(this.startTile, this.endTile);
    }

    private void relocateStart(MapTile newStart)
    {
        this.startTile = newStart;
        calcBridgePath();
    }

    private void relocateEnd(MapTile newEnd)
    {
        this.endTile = newEnd;
        calcBridgePath();
    }
}
