using UnityEngine;

public class MapPiece : MonoBehaviour
{

    private MapManager map;

    private Transform endPoint;

    void Awake()
    {
        map = FindObjectOfType<MapManager>();
    }

    void Start()
    {
        endPoint = transform.Find("EndPoint");

        if (map.currentSize < map.mapSize)
        {
            map.SpawnRoom(endPoint);
            map.currentSize++;
        }
        else
        if (map.currentSize == map.mapSize)
        {
            map.SpawnFinalRoom(endPoint);
        }
    }

}
