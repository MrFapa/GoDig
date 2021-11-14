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

        calcBridgePath(i1.CenterPoint, i2.CenterPoint);
    }

    private void calcBridgePath(Vector2Int start, Vector2Int end)
    {
        this.bridgePath = BridgeBuilder.findBridgePath(start, end);
        this.startTile = (MapTile)this.bridgePath[0];
        this.endTile = (MapTile)this.bridgePath[bridgePath.Count - 1];
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
