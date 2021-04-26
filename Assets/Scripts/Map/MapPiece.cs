using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPiece : MonoBehaviour
{
    private MapManager map;
    private Transform endPoint;

    private void Awake()
    {
        map = FindObjectOfType<MapManager>();
        endPoint = transform.Find("EndPoint");
    }

    void Start()
    {
        if(map.currentSize < map.mapSize)
        {
            map.SpawnRoom(endPoint);
            map.currentSize++;
        } else if (map.currentSize == map.mapSize)
        {
            map.SpawnFinalRoom(endPoint);
        }
    }
}
