using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder
{

    public static List<Node> findPath(Vector3 startPos, Vector3 targetPos, PlayerGrid grid, bool ignoreWalkable)
    {
        Node startNode = grid.nodeFromWorldPoint(startPos);
        Node targetNode = grid.nodeFromWorldPoint(targetPos);

        List<Node> openSet = new List<Node>();
        HashSet<Node> closedSet = new HashSet<Node>();

        openSet.Add(startNode);

        while (openSet.Count > 0)
        {

            Node currentNode = openSet[0];
            if(!ignoreWalkable){
                if (!currentNode.walkable)
                {
                    return new List<Node>();
                }
            }
            
            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].getFCost() < currentNode.getFCost() || (openSet[i].getFCost() == currentNode.getFCost() && openSet[i].hCost < currentNode.hCost))
                {
                    currentNode = openSet[i];
                }
            }

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if (currentNode == targetNode)
            {
                return retracePath(startNode, targetNode);
            }

            foreach (Node neighbour in grid.searchNeighbours(currentNode))
            {
                if (closedSet.Contains(neighbour))
                {
                    continue;
                }
                if(!neighbour.walkable && !ignoreWalkable){
                    continue;
                }

                int newMovCost = currentNode.gCost + getDistance(currentNode, neighbour);
                if (newMovCost < neighbour.gCost || !openSet.Contains(neighbour))
                {
                    neighbour.gCost = newMovCost;
                    neighbour.hCost = getDistance(neighbour, targetNode);
                    neighbour.parent = currentNode;

                    if (!openSet.Contains(neighbour))
                    {
                        openSet.Add(neighbour);

                    }

                }
            }
        }
        return new List<Node>();
    }

    static List<Node> retracePath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Add(startNode);
        path.Reverse();

        return path;

    }

    static int getDistance(Node nodeA, Node nodeB)
    {
        int dstX = Mathf.Abs((int)(nodeA.worldPosition.x - nodeB.worldPosition.x));
        int dstY = Mathf.Abs((int)(nodeA.worldPosition.y - nodeB.worldPosition.y));

        if (dstX > dstY)
        {
            return 14 * dstY + 10 * (dstX - dstY);
        }
        return 14 * dstX + 10 * (dstY - dstX);
    }
}
