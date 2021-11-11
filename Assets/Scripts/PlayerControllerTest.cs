using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTest : MonoBehaviour
{
    public float speed;
    public float radius;
    public float yOffset;

    public GameObject pg;

    private Pathfinder pf;
    private List<Node> path;

    private bool isMoving = false;

    private Vector3 nextPos;

    void Start()
    {

        path = new List<Node>();
        
        ArrayList possibleTiles = GameObject.Find("MapManager").GetComponent<MapManager>().Map.getMapTiles(new[] { LandTypes.LandValueType.land });
        int rdmNumber = Random.Range(0, possibleTiles.Count);
        Vector2Int playerPos = ((MapTile)possibleTiles[rdmNumber]).Position;
        this.transform.position = new Vector3(playerPos.x + .5f, playerPos.y + .5f, 0);
        nextPos = transform.position;
    }

    void Update()
    {

/*        if (path.Count > 1)
        {
            for (int i = 0; i < path.Count - 1; i++)
            {
                Debug.DrawLine(new Vector3(path[i].worldPosition.x, path[i].worldPosition.y, 1), new Vector3(path[i + 1].worldPosition.x, path[i + 1].worldPosition.y, 1), Color.red);
            }
        }


        if (Input.GetMouseButtonDown(0))
        {
            if (!isMoving)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint((Input.mousePosition));
                mousePosition.z = 0;
                receivePath(mousePosition);
            }

        }*/
    }

    // Update is called once per fram
    void FixedUpdate()
    {
        move();
    }

    void receivePath(Vector3 posToMove)
    {
        path = null;
        path = Pathfinder.findPath(transform.position, posToMove, GameObject.Find("Playergrid").GetComponent<PlayerGrid>(), false);

        string line = "";
        foreach (Node node in path)
        {
            line += node.worldPosition + " ";
        }
        Debug.Log(line);

    }

    void move()
    {
        if (path.Count > 0)
        {
            Vector3 dir = nextPos - transform.position;
            dir.Normalize();
            transform.position = Vector3.Lerp(transform.position, nextPos, Time.fixedDeltaTime);
            transform.position = Vector3.Lerp(transform.position, nextPos, Time.fixedDeltaTime);

            Vector3 dist = transform.position - nextPos;

            if (dist.magnitude < radius)
            {
                transform.position = nextPos;
                if (path.Count > 1)
                {
                    path.RemoveAt(0);
                    nextPos = path[0].worldPosition + new Vector2(0.5f, yOffset);
                }
                else if (path.Count == 1)
                {
                    path.RemoveAt(0);
                }
                else
                {
                    nextPos = transform.position;
                }
            }
        }

    }
}