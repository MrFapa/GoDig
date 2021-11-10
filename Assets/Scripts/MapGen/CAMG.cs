using UnityEngine;
using System.Linq;

public class CAMG
{
    public static MapTile[,] generateMap(MapTile[,] map, int runs, int waterLevel)
    {
        map = randomize(map, waterLevel);
        map = smoothen(map, runs);
        return map;
    }

    static MapTile[,] randomize(MapTile[,] map, int waterLevel)
    {
        for(int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                map[i, j].Value = (Random.Range(0, 1000) > waterLevel) ? 1 : 0;
            }
        }
        return map;
    }

    static MapTile[,] smoothen(MapTile[,] map, int runs)
    {
        for (int run = 0; run < runs; run++)
        {
            int[,] mapUpdate = new int[map.GetLength(0), map.GetLength(1)];
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    mapUpdate[i, j] = checkNextGenOfTile(map[i, j].getNeighbours());
                }
            }

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j].Value = mapUpdate[i, j];
                }
            }
        }
        return map;
    }

    static int checkNextGenOfTile(Neighbours neighbours)
    {
        int landcount = 0;
        foreach(MapTile neighbour in neighbours.allNeighbours)
        {
            landcount += neighbour.Value;
        }
        if (landcount >= 5)
            return 1;

        return 0;
    }
}
