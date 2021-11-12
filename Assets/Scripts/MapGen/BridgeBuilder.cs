using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LandTypes;

public class BridgeBuilder
{
    public static void findBridgePath(Island island1, Island island2)
    {
        Vector2Int c1 = island1.CenterPoint;
        Vector2Int c2 = island2.CenterPoint;

        Vector3 start = new Vector3(c1.x, c1.y, 0);
        Vector3 target = new Vector3(c2.x, c2.y, 0);

        PlayerGrid grid = GameObject.Find("PlayerGrid").GetComponent<PlayerGrid>();
        List<Node> path = Pathfinder.findPath(start, target, grid, true);

        //Set new start and end maptile (start = last coast tile of island1, end = first coast tile of island2)
        if (path.Count > 2)
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
        }




        for (int i = 0; i < path.Count; i++)
        {
            if (Converter.NodeToMaptile(path[i]).LandValue == LandValueType.water || Converter.NodeToMaptile(path[i]).LandValue == LandValueType.coast)
            {
                Converter.NodeToMaptile(path[i]).LandValue = LandValueType.bridge;
            }
        }

    }



}
