using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject spwanee;

    [SerializeField]
    private float spawnTime;
    [SerializeField]
    private float spawnRate;

    [SerializeField]
    private int spawnNumber;

    public bool stopSpawning = false;

    private List<Slime> slimes = new List<Slime>();

    private Vector3 spawnPosition;

    private const string spawnMethod = "Spawn";

    public int SlimesCount()
    {
        return slimes.Count;
    }

    void Start()
    {
        spawnPosition = new Vector3(transform.position.x + (transform.localScale.x / 2f), transform.position.y, transform.position.y);

        InvokeRepeating(spawnMethod, spawnTime, spawnRate);
    }

    private void Spawn()
    {
        if (stopSpawning == false)
        {
            GameObject instantiatedSpawn = Instantiate(spwanee, spawnPosition, transform.rotation);

            instantiatedSpawn.transform.SetParent(transform);

            slimes.Add(instantiatedSpawn.GetComponent<Slime>());
        
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

}
