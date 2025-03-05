using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject[] platforms; // Array to hold different platform prefabs
    public Transform player; // Reference to the player's transform
    public float spawnDistance = 50f; // Distance ahead of the player to spawn platforms
    public float platformLength = 30f; // Length of each platform
    public int initialPlatforms = 5; // Number of platforms to spawn initially
    public int maxPlatforms = 10; // Maximum number of platforms in the scene

    private Queue<GameObject> activePlatforms = new Queue<GameObject>(); // Queue to manage active platforms
    private float lastSpawnZ; // Z-position of the last spawned platform

    void Start()
    {
        lastSpawnZ = player.position.z - platformLength; // Initialize the lastSpawnZ value
        for (int i = 0; i < initialPlatforms; i++)
        {
            SpawnPlatform();
        }
    }

    void Update()
    {
        // Check if the player is near the end of the last spawned platform
        if (player.position.z + spawnDistance > lastSpawnZ)
        {
            SpawnPlatform();
        }

        // Remove and destroy platforms the player has passed
        if (activePlatforms.Count > maxPlatforms)
        {
            GameObject oldPlatform = activePlatforms.Dequeue();
            Destroy(oldPlatform);
        }
    }

    void SpawnPlatform()
    {
        int level = PlayerPrefs.GetInt("Level", 1) - 1; // Get the level from PlayerPrefs, default to 1
        level = Mathf.Clamp(level, 0, platforms.Length - 1); // Ensure level is within bounds

        GameObject platformPrefab = platforms[level];
        Vector3 spawnPosition = new Vector3(0, -0.5f, lastSpawnZ + platformLength);

        GameObject newPlatform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        activePlatforms.Enqueue(newPlatform);

        lastSpawnZ += platformLength; // Update the lastSpawnZ for the next platform
    }
}
