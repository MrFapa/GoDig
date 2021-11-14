using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LandTypes;

public class BridgeBuilder
{
    public static ArrayList findBridgePath(MapTile startTile, MapTile endTile)
    {
        Vector3 start = new Vector3(startTile.Position.x, startTile.Position.y, 0);
        Vector3 target = new Vector3(endTile.Position.x, endTile.Position.y, 0);

        PlayerGrid grid = GameObject.Find("PlayerGrid").GetComponent<PlayerGrid>();
        List<Node> path = Pathfinder.findPath(start, target, grid, true);

        //Set new start and end maptile (start = last coast tile of island1, end = first coast tile of island2)
        /*if (path.Count > 2)
        {
            int indexOfNewStart = 0;
            int indexOfNewEnd = 0;

            for (int i = 0; i < path.Count; i++)
            {
                MapTile currentMapTile = Converter.NodeToMaptile(path[i]);
                if (island1.contains(currentMapTile) && currentMapTile.LandValue == LandValueType.coast)
                {
                    indexOfNewStart = i;
                }

                if (island2.contains(currentMapTile) && currentMapTile.LandValue == LandValueType.coast && !(indexOfNewEnd != 0))
                {
                    indexOfNewEnd = i;
                }
            }
            path.RemoveRange(indexOfNewEnd, path.Count - indexOfNewEnd);
            path.RemoveRange(0, indexOfNewStart);
     } */

        ArrayList bridgePath = new ArrayList();
        for (int i = 0; i < path.Count; i++)
        {
            if (Converter.NodeToMaptile(path[i]).LandValue == LandValueType.water || Converter.NodeToMaptile(path[i]).LandValue == LandValueType.coast)
            {
                bridgePath.Add(Converter.NodeToMaptile(path[i]));
                Converter.NodeToMaptile(path[i]).LandValue = LandValueType.bridge;
            }
        }
        return bridgePath;
    }

    public static ArrayList findBridgePath(Vector2Int start, Vector2Int end)
    {
        MapTile startTile = GameObject.Find("MapManager").GetComponent<MapManager>().Map.getTile(start);
        MapTile endTile = GameObject.Find("MapManager").GetComponent<MapManager>().Map.getTile(end);
        return findBridgePath(startTile, endTile);
    }

    public static ArrayList buildBridges(Island[] islands)
    {
        Vector2Int[] centerPoints = new Vector2Int[islands.Length];
        for (int i = 0; i < islands.Length; i++)
        {
            centerPoints[i] = islands[i].CenterPoint;
        }


        ArrayList islandpairs = new ArrayList();
        for (int i = 0; i < centerPoints.Length; i++)
        {
            Vector2Int currentCenterPoint = centerPoints[i];
            float lowestDistance = 0;
            int index = -1;
            for (int j = 0; j < centerPoints.Length; j++)
            {
                if (i == j)
                    continue;

                if (lowestDistance == 0 || lowestDistance > (currentCenterPoint - centerPoints[j]).magnitude)
                {
                    lowestDistance = (currentCenterPoint - centerPoints[j]).magnitude;
                    index = j;
                }
            }

            if (index >= 0)
            {
                Vector2Int pair;
                if (i < index)
                {
                    pair = new Vector2Int(i, index);
                }
                else
                {
                    pair = new Vector2Int(index, i);
                }

                if (!islandpairs.Contains(pair))
                {
                    islandpairs.Add(pair);
                }
            }
        }

        ArrayList bridges = new ArrayList();

        foreach (Vector2Int pair in islandpairs)
        {
            Bridge newBridge = new Bridge(islands[pair.x], islands[pair.y]);
            bridges.Add(newBridge);
        }
        return bridges;
    }



}
