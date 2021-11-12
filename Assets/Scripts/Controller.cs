using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject PlayerGrid;
    public GameObject MapGenerator;
    public GameObject Player;
    void Start()
    {
        PlayerGrid.GetComponent<PlayerGrid>().init();
        MapGenerator.GetComponent<MapGenerator>().InitMap();
        MapGenerator.GetComponent<MapGenerator>().addBridge();
        MapGenerator.GetComponent<MapGenerator>().drawMap();
        Player.GetComponent<PlayerControllerTest>().placePlayer();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
