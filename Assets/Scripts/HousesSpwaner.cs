using System.Collections.Generic;
using UnityEngine;

public class SideSpawner : MonoBehaviour
{
    public List<GameObject> level1Objects; // Objects for Level 1
    public List<GameObject> level2Objects; // Objects for Level 2

    public float spawnDistance = 100f; // Distance ahead of the player to spawn objects
    public float destroyDelay = 15f; // Time before destroying spawned objects
    public Transform player; // Reference to the player's transform
    public float leftXOffset = -10f; // X position for the left side
    public float rightXOffset = 10f; // X position for the right side
    public float spawnInterval = 1f; // Interval between spawns

    private float timer = 0f;
    private int level = 1; // Default level

    void Start()
    {
        // Load the level from PlayerPrefs (default to 1 if not set)
        level = PlayerPrefs.GetInt("Level", 1);
    }

    void Update()
    {
        if (player == null) return;

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnObjectsOnSides();
            timer = 0f;
        }
    }

    private void SpawnObjectsOnSides()
    {
        List<GameObject> currentLevelObjects = GetCurrentLevelObjects();
        if (currentLevelObjects.Count == 0) return;

        // Randomly decide whether to spawn on the left, right, or both
        bool spawnOnLeft = Random.value > 0.3f; // ~70% chance to spawn on the left
        bool spawnOnRight = Random.value > 0.3f; // ~70% chance to spawn on the right

        if (spawnOnLeft)
        {
            SpawnObject(currentLevelObjects, leftXOffset);
        }

        if (spawnOnRight)
        {
            SpawnObject(currentLevelObjects, rightXOffset);
        }
    }

    private void SpawnObject(List<GameObject> objectsPool, float xOffset)
    {
        Vector3 spawnPosition = new Vector3(xOffset, -0.5f, player.position.z + spawnDistance);
        GameObject prefab = objectsPool[Random.Range(0, objectsPool.Count)];
        GameObject spawnedObject = Instantiate(prefab, spawnPosition, prefab.transform.rotation);
        Destroy(spawnedObject, destroyDelay);
    }

    private List<GameObject> GetCurrentLevelObjects()
    {
        // Return objects based on the current level
        return level == 1 ? level1Objects : level2Objects;
    }
}
