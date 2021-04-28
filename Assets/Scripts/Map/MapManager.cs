using UnityEngine;

public class MapManager : MonoBehaviour
{
    
    public int mapSize;

    [HideInInspector]
    public int currentSize;

    [SerializeField]
    GameObject[] rooms;

    [SerializeField]
    GameObject finalRoom;
    [SerializeField]
    GameObject firstRoom;

    Transform firstPoint;
    
    void Start()
    {
        firstPoint = firstRoom.transform.Find("TunnelStart");

        BeginCreation();
    }

    void BeginCreation()
    {
        SpawnRoom(firstPoint);
    }

    internal void SpawnFinalRoom(Transform spawnPoint)
    {
        GameObject finalRoomGameObject = Instantiate(finalRoom, spawnPoint.position, Quaternion.identity, transform);
    }

    public void SpawnRoom(Transform spawnPoint)
    {
        int rdm = Random.Range(0, rooms.Length);
        GameObject piece = Instantiate(rooms[rdm], spawnPoint.position, Quaternion.identity, transform);
    }

}
