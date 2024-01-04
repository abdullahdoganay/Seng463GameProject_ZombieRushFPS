using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform[] spawnPoints;
    public float initialTimeBetweenSpawns = 5f;
    public float timeBetweenStages = 30f;

    private float timeBetweenSpawns;
    private float timer;
    private int currentZombieCount = 0;
    private int stage = 1;

    // Start is called before the first frame update
    void Start()
    {
        timeBetweenSpawns = initialTimeBetweenSpawns;
        InvokeRepeating("SpawnZombies", 0f, timeBetweenSpawns);
    }

    void SpawnZombies()
    {
        Transform spawnPoint = spawnPoints[currentZombieCount];
        for (int i = 0; i < stage; i++)
        {
            Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);
        }
        currentZombieCount++;

        if (currentZombieCount == spawnPoints.Length)
        {
            currentZombieCount = 0;
            timer += timeBetweenSpawns;

            // Check if it's time to increase the spawn rate
            if (timer >= timeBetweenStages)
            {
                timer = 0;
                IncreaseSpawnRate();
            }
        }
    }

    void IncreaseSpawnRate()
    {
        // Increase the spawn rate and update the stage
        timeBetweenSpawns /= 2;
        stage++;

        // Ensure the spawn rate doesn't go below a certain value
        if (timeBetweenSpawns < 0.5f)
        {
            timeBetweenSpawns = 0.5f;
        }
    }
}
