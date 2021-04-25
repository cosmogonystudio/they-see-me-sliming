using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    
    public int mapSize;
    [HideInInspector] public int currentSize;
    //[SerializeField] GameObject[] pieces;
    [SerializeField] GameObject[] halls, rooms;
    [SerializeField] GameObject finalRoom, FirstRoom;
    Transform firstPoint;
    float roomChance, rdmChance;


    private void Awake()
    {
        firstPoint = FirstRoom.transform.Find("TunnelStart");
        BeginCreation();
    }

    void BeginCreation()
    {
        SpawnNextPiece(firstPoint);
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

    internal void SpawnNextPiece(Transform spawnPoint)
    {
        rdmChance = UnityEngine.Random.Range(0, 1f);

        if(rdmChance < roomChance)
        {
            SpawnRoom(spawnPoint);
        } else {
            SpawnHall(spawnPoint);
        }
    }

    private void SpawnHall(Transform spawnPoint)
    {
        int rdm = UnityEngine.Random.Range(0, halls.Length);
        GameObject Piece = Instantiate(halls[rdm], spawnPoint.position, Quaternion.identity, transform);
        roomChance += 0.335f;
    }

    int rdm = 0; 
    private void SpawnRoom(Transform spawnPoint)
    {
        Debug.Log(rdm);
        if(rdm == rooms.Length - 1)
        {
            rdm = 0;
        }
        rdm = UnityEngine.Random.Range(rdm, rooms.Length);
        GameObject Piece = Instantiate(rooms[rdm], spawnPoint.position, Quaternion.identity, transform);
        roomChance = 0;
    }
}
