using System.Collections;
using UnityEngine;

public class ObjectCloner : MonoBehaviour
{
    public GameObject objectToClone;  // The object to be cloned
    public Transform[] cloneSpawnPoints; // Array of points where the clone will be spawned
    public float spawnInterval = 2f;  // Time interval between spawns
    private bool _shouldSpawn = true;  // Condition to control the spawning

    void Start()
    {
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        while (_shouldSpawn)
        {
            yield return new WaitForSeconds(spawnInterval);
            CloneObject();
        }
    }

    void CloneObject()
    {
        if (cloneSpawnPoints.Length == 0) return;

        // Select a random spawn point from the array
        Transform spawnPoint = cloneSpawnPoints[Random.Range(0, cloneSpawnPoints.Length)];
        GameObject clone = Instantiate(objectToClone, spawnPoint.position, spawnPoint.rotation);
        Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 1;
        }
    }

    // Call this method to stop the spawning process
    public void StopSpawning()
    {
        _shouldSpawn = false;
    }
}