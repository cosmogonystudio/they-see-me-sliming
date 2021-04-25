using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPiece : MonoBehaviour
{
    private MapManager map;
    private Transform spawnPoint;

    private void Awake()
    {
        map = FindObjectOfType<MapManager>();
        spawnPoint = transform.Find("SpawnPoint");
    }

    void Start()
    {
        if(map.currentSize < map.mapSize)
        {
            map.SpawnNextPiece(spawnPoint);
            map.currentSize++;
        } else if (map.currentSize == map.mapSize)
        {
            map.SpawnFinalRoom(spawnPoint);
        }
    }
}
