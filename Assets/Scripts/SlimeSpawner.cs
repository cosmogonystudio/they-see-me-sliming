using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{

    public enum SpawnType
    {
        None,
        Up,
        Right
    }

    [SerializeField]
    private GameObject spwanee;

    [SerializeField]
    private float spawnTime;
    [SerializeField]
    private float spawnRate;

    [SerializeField]
    private int spawnNumber;

    [SerializeField]
    private SpawnType spawnType;

    private bool stopSpawning = false;

    private List<Slime> slimes = new List<Slime>();

    private Vector3 spawnPosition;

    private const string spawnMethod = "Spawn";

    public void Spawn()
    {
        if (stopSpawning == false)
        {
            GameObject instantiatedSpawn = Instantiate(spwanee, spawnPosition, Quaternion.identity);

            instantiatedSpawn.transform.SetParent(transform);

            Slime slime = instantiatedSpawn.GetComponent<Slime>();

            switch (spawnType)
            {
                case SpawnType.Up:
                    slime.Fall();
                    break;
                case SpawnType.Right:
                    slime.KeepWalking();
                    break;
                default:
                    slime.KeepWalking();
                    break;
            }

            slimes.Add(slime);

            if (slimes.Count >= spawnNumber)
            {
                stopSpawning = true;
            }
        }
        else
        {
            CancelInvoke(spawnMethod);
        }
    }

    public int SlimesCount()
    {
        return slimes.Count;
    }

    void Start()
    {
        switch (spawnType)
        {
            case SpawnType.Up:
                spawnPosition = new Vector3(transform.position.x, transform.position.y + (transform.localScale.y / 2f), transform.position.z);
                break;
            case SpawnType.Right:
                spawnPosition = new Vector3(transform.position.x + (transform.localScale.x / 2f), transform.position.y, transform.position.z);
                break;
            default:
                spawnPosition = transform.position;
                break;
        }
        
        InvokeRepeating(spawnMethod, spawnTime, spawnRate);
    }

}
