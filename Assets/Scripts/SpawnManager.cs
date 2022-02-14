using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;

    private float spawnPositionRange = 9f;
    private Vector3 positionOffset = new Vector3(0, 0, 0);

    private int enemiesPerWave = 0;
    private int enemiesLeft;

    void Start()
    {
        SpawnEnemyWave(enemiesPerWave);
    }

    private void Update()
    {
        enemiesLeft = FindObjectsOfType<Enemy>().Length;

        if (enemiesLeft <= 0)
        {
            enemiesPerWave++;

            SpawnEnemyWave(enemiesPerWave);

            Instantiate(powerUpPrefab, RandomSpawnPosition(), transform.rotation);
        }

    }

    private Vector3 RandomSpawnPosition()
    {
        positionOffset.x = Random.Range(-spawnPositionRange, spawnPositionRange + 1);
        positionOffset.z = Random.Range(-spawnPositionRange, spawnPositionRange + 1);

        return positionOffset;
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, RandomSpawnPosition(), transform.rotation);
    }

    private void SpawnEnemyWave(int totalEnemies)
    {
        for (int i = 0; i < totalEnemies; i++)
        {
            SpawnEnemy();
        }
    }
}
