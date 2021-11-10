using UnityEngine;
using LandTypes;
using System.Linq;

public class CellularAutomataMapGenerator
{
    public static void generateMap(ref Map map, int runs, int waterLevel)
    {
        randomize(ref map, waterLevel);
        smoothen(ref map, runs);
    }

    static void randomize(ref Map map, int waterLevel)
    {
        for(int i = 0; i < map.Size; i++)
        {
            for (int j = 0; j < map.Size; j++)
            {
                map.getTile(new Vector2Int(i, j)).LandValue = (Random.Range(0, 1000) > waterLevel) ? landValueType.land : landValueType.water;
            }
        }
    }

    static void smoothen(ref Map map, int runs)
    {
        for (int run = 0; run < runs; run++)
        {
            landValueType[,] mapUpdate = new landValueType[map.Size, map.Size];
            for (int i = 0; i < map.Size; i++)
            {
                for (int j = 0; j < map.Size; j++)
                {
                    mapUpdate[i, j] = getSmoothedLandValueType(map.getTile(new Vector2Int(i, j)).getNeighbours());
                }
            }

            for (int i = 0; i < map.Size; i++)
            {
                for (int j = 0; j < map.Size; j++)
                {
                    map.getTile(new Vector2Int(i, j)).LandValue = mapUpdate[i, j];
                }
            }
        }
    }

    static landValueType getSmoothedLandValueType(Neighbours neighbours)
    {
        int landcount = 0;
        foreach(MapTile neighbour in neighbours.allNeighbours)
        {
            if((neighbour != null) && (neighbour.LandValue == landValueType.land))
            {
                landcount++;
            }
        }
        if (landcount >= 5)
            return landValueType.land;

        return landValueType.water;
    }
}
