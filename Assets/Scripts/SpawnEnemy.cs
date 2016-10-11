using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {


    //Spawn this object
    public GameObject playerObject;

    public float maxTime = 5;
    public float minTime = 2;



    //current time
    private float time;

    //The time to spawn the object
    private float spawnTime;

    private int maxEnemyIndex;

    public static int maximumEnemiesToSpawn = 3;
    private static int spawnedEnemiesCount;

    void Start()
    {
        maxEnemyIndex = Resources.LoadAll("Enemies").Length;
        spawnedEnemiesCount = 0;
        SetRandomTime();
        time = minTime;
    }

    void FixedUpdate()
    {
        //Counts up
        time += Time.deltaTime;

        //Check if its the right time to spawn the object
        if (time >= spawnTime)
        {
            if(spawnedEnemiesCount < maximumEnemiesToSpawn)
                SpawnObject();
            SetRandomTime();
        }

    }


    //Spawns the object and resets the time
    void SpawnObject()
    {

        float height = 2.0f * Camera.main.orthographicSize;
        float cameraWidth = height * Camera.main.aspect;


        int spawnIndex = Random.Range(0, maxEnemyIndex);
        time = 0;
        Instantiate(Resources.Load("Enemies/en_" + spawnIndex) as GameObject
                    , new Vector2(playerObject.transform.position.x + 110, playerObject.transform.position.y)
                    , Quaternion.identity);
        spawnedEnemiesCount++;
    }

    //Sets the random time between minTime and maxTime
    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }

    public static void DecreaseSpawnedEnemies(int count = 1)
    {
        spawnedEnemiesCount = spawnedEnemiesCount - count;
    }
}
