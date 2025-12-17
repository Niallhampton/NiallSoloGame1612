using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    public GameObject spikePrefab;
    public Transform player;

    //distance ahead of the player where spikes should spawn
    public float spawnDistance = 20f;

    //minimum and maximum Y positions for random spike placement
    public float minY = -4.7f;
    public float maxY = -4.4f;

    //distance between each spike
    public float spawnInterval = 3f;

    //position where the next spike will be spawned
    private float nextSpawnX;

    void Start()
    {
        //set the location of first spawned spike ahead of the player
        nextSpawnX = player.position.x + spawnDistance;
    }

    void Update()
    {
        //check to see if the player has moved far enough to trigger a new spike
        if (player.position.x + spawnDistance >= nextSpawnX)
        {
            SpawnSpike();
        }
    }

    void SpawnSpike()
    {
        //choose a random Y value within the range
        float randomY = Random.Range(minY, maxY);

        //create the spawn position using the next X value
        Vector3 spawnPos = new Vector3(nextSpawnX, randomY, 0f);

        //put the spike prefab at the calculated position
        Instantiate(spikePrefab, spawnPos, Quaternion.identity);

        //move the next spike position forward by the interval value
        nextSpawnX += spawnInterval;
    }
}

