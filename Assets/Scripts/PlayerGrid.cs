using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrid : MonoBehaviour
{
    private Node[,] grid;
    private int size;

    void Start()
    {
        size = GameObject.Find("MapManager").GetComponent<MapManager>().MapSize;
        grid = new Node[size, size];
        initGrid();
        updateGrid();
    }

    private void initGrid()
    {
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                grid[x, y] = new Node(false, new Vector2(x, y));
            }

        }

    }

    public void updateGrid()
    {
        bool[,] walkableGrid = WalkalbeCalculator.calculateWalkable();
        for (int x = 0; x < walkableGrid.GetLength(0); x++)
        {
            for (int y = 0; y < walkableGrid.GetLength(1); y++)
            {
                grid[x, y].walkable = walkableGrid[x, y];
            }
        }
    }

    public List<Node> searchNeighbours(Node node)
    {
        List<Node> neighbours = new List<Node>();
        for(int i = -1; i < 2; i++)
        {
            for(int j = -1; j < 2; j++)
            {
                if(i == 0 && j == 0 || i == -1 && j == -1 || i == 1 && j == -1 || i == -1 && j == 1 || i == 1 && j == 1) 
                {
                    continue;
                }
                int x = (int) node.worldPosition.x - i;
                int y = (int) node.worldPosition.y - j;

                if(x >= 0 && x < size && y >= 0 && y < size)
                {
                    neighbours.Add(grid[x, y]);
                }
            }
        }

        return neighbours;
    }

    public Node nodeFromWorldPoint(Vector3 worldPosition)
    {
        int x = (int) worldPosition.x;
        int y = (int) worldPosition.y;

        return grid[x, y];
    }

}
