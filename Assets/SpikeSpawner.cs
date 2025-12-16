using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    public GameObject spikePrefab;
    public Transform player;

    public float spawnDistance = 20f;
    public float minY = -4.7f;
    public float maxY = -4.4f;
    public float spawnInterval = 3f;

    private float nextSpawnX;

    void Start()
    {
        nextSpawnX = player.position.x + spawnDistance;
    }

    void Update()
    {

        if (player.position.x + spawnDistance >= nextSpawnX)
        {
            SpawnSpike();
        }
    }

    void SpawnSpike()
    {
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(nextSpawnX, randomY, 0f);
        Instantiate(spikePrefab, spawnPos, Quaternion.identity);
        nextSpawnX += spawnInterval;
    }
}

