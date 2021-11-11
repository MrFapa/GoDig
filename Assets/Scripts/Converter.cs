using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Converter
{
    public static MapTile NodeToMaptile(Node node)
    {
        Vector2Int pos = new Vector2Int((int)node.worldPosition.x, (int)node.worldPosition.y);
        return GameObject.Find("MapManager").GetComponent<MapManager>().Map.getTile(pos.x, pos.y);
    }

    public static Node maptileToNode(MapTile tile)
    {
        return GameObject.Find("Playergrid").GetComponent<PlayerGrid>().nodeFromWorldPoint(tile.Position.x, tile.Position.y);
    }
}
