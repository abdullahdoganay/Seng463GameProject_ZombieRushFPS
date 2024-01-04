
using UnityEngine;

public class HealthSpawnController : MonoBehaviour
{

    public GameObject applePrefab;
    public Transform[] spawnPoints;
    public float timeBetweenSpawns1 = 80f;
    public float timeBetweenSpawns2 = 40f;
    public float timeBetweenSpawns3 = 30f;
    public float timeBetweenSpawns4 = 15f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnApple1", 0f, timeBetweenSpawns1);
        InvokeRepeating("SpawnApple2", 0f, timeBetweenSpawns2);
        InvokeRepeating("SpawnApple3", 0f, timeBetweenSpawns3);
        InvokeRepeating("SpawnApple4", 0f, timeBetweenSpawns4);
    }

    void SpawnApple1()
    {

        Transform spawnPoint = spawnPoints[0];
        Instantiate(applePrefab, spawnPoint.position, spawnPoint.rotation);

    }
    void SpawnApple2()
    {


        Transform spawnPoint = spawnPoints[1];
        Instantiate(applePrefab, spawnPoint.position, spawnPoint.rotation);


    }
    void SpawnApple3()
    {


        Transform spawnPoint = spawnPoints[2];
        Instantiate(applePrefab, spawnPoint.position, spawnPoint.rotation);


    }
    void SpawnApple4()
    {


        Transform spawnPoint = spawnPoints[3];
        Instantiate(applePrefab, spawnPoint.position, spawnPoint.rotation);


    }
}
