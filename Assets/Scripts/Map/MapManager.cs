using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    
    public int mapSize;
    [HideInInspector] public int currentSize;
    //[SerializeField] GameObject[] pieces;
    [SerializeField] GameObject[] rooms;
    [SerializeField] GameObject finalRoom, FirstRoom;
    Transform firstPoint;
    


    private void Awake()
    {
        firstPoint = FirstRoom.transform.Find("TunnelStart");
        BeginCreation();
    }

    void BeginCreation()
    {
        SpawnRoom(firstPoint);
    }

    internal void SpawnFinalRoom(Transform spawnPoint)
    {
        GameObject FinalRoom = Instantiate(finalRoom, spawnPoint.position, Quaternion.identity, transform);
    }

    /*internal void SpawnNextPiece(Transform spawnPoint)
    {
        int rdm = UnityEngine.Random.Range(0, pieces.Length);
        GameObject Piece = Instantiate(pieces[rdm], spawnPoint.position, Quaternion.identity, transform);
    }*/
 
    public void SpawnRoom(Transform spawnPoint)
    {
        int rdm = UnityEngine.Random.Range(0, rooms.Length);
        GameObject Piece = Instantiate(rooms[rdm], spawnPoint.position, Quaternion.identity, transform);
    }
}
