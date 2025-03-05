using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public float maxTime = 1.5f;            // Initial time interval between spawns
    private float timer = 0f;

    public float obstacleLifetime = 15f; // Time before spawned objects are destroyed

    public GameObject[] obstaclePrefabs; // Array for obstacle prefabs
    public GameObject coinPrefab;        // Prefab for coin

    private float[] lanes = { -3f, 0f, 3f }; // Fixed lanes on the X-axis

    public float difficultyIncreaseRate = 0.5f; // Time interval to increase difficulty
    public float minMaxTime = 0.2f;            // Minimum value for maxTime to avoid it becoming too fast
    public float timeDecreaseStep = 0.02f;      // Amount to decrease maxTime during each difficulty increase

    private float difficultyTimer = 0f;        // Timer to track when to increase difficulty

    void Update()
    {
        timer += Time.deltaTime;
        difficultyTimer += Time.deltaTime;

        if (timer >= maxTime)
        {
            SpawnRandomObject();
            timer = 0f;
        }

        if (difficultyTimer >= difficultyIncreaseRate)
        {
            IncreaseDifficulty();
            difficultyTimer = 0f;
        }
    }

    private void SpawnRandomObject()
    {
        int randomType = Random.Range(1, 11); // Randomize type of object to spawn (1-10)

        if (randomType <= 7)
        {
            // Spawn obstacle (70% chance)
            SpawnObstacle();
        }
        else
        {
            // Spawn coin (30% chance)
            SpawnCoin();
        }
    }

    private void SpawnObstacle()
    {
        int randomPrefabIndex = Random.Range(0, obstaclePrefabs.Length); // Select random obstacle prefab
        int randomLaneIndex = Random.Range(0, lanes.Length);             // Select random lane
        int randomVerticalLaneIndex = Random.Range(0, lanes.Length);

        GameObject obstacle = Instantiate(obstaclePrefabs[randomPrefabIndex]);
        obstacle.transform.position = new Vector3(lanes[randomLaneIndex], lanes[randomVerticalLaneIndex], transform.position.z);
        Destroy(obstacle, obstacleLifetime);
    }

    private void SpawnCoin()
    {
        int randomLaneIndex = Random.Range(0, lanes.Length); // Select random lane

        GameObject coin = Instantiate(coinPrefab);
        coin.transform.position = new Vector3(lanes[randomLaneIndex], 1f, transform.position.z); // Coins appear slightly above ground
        Destroy(coin, obstacleLifetime);
    }

    private void IncreaseDifficulty()
    {
        if (maxTime > minMaxTime)
        {
            maxTime -= timeDecreaseStep;
            maxTime = Mathf.Max(maxTime, minMaxTime); // Ensure maxTime doesn't go below minMaxTime
            Debug.Log($"Difficulty increased! New maxTime: {maxTime}");
        }
    }
}
