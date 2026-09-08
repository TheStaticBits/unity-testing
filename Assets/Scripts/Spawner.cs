using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate;
    public static float spawnDistance = 12;
    
    private float timeSinceLastSpawn;

    
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn -= Time.deltaTime;
        if (timeSinceLastSpawn <= 0 && player.GetComponent<PlayerHealth>().IsAlive())
        {
            SpawnEnemy();
            timeSinceLastSpawn = spawnRate;
        }
    }

    private void SpawnEnemy()
    {
        // spawn on the edges of a circle around the spawner object
        Vector2 spawnPos = Random.insideUnitCircle.normalized * spawnDistance;
        spawnPos += (Vector2)transform.position;

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
