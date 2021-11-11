using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeBuilder
{
    public static void findBridgePath(Island island1, Island island2)
    {
        Vector2Int c1 = island1.CenterPoint;
        Vector2Int c2 = island2.CenterPoint;

        Vector3 start = new Vector3(c1.x, c1.y, 0);
        Vector3 target = new Vector3(c2.x, c2.y, 0);

        PlayerGrid grid = GameObject.Find("Playergrid").GetComponent<PlayerGrid>();
        List<Node> path = Pathfinder.findPath(start, target, grid);

        foreach (Node node in path)
        {
            //Gizmos.DrawCube(new Vector3(node.worldPosition.x, node.worldPosition.y, 0), new Vector3(1, 1, 0));
        }
    }

    public static void constructBridgePath(MapTile[] path)
    {

    }


}
