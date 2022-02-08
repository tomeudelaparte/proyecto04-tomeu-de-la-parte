using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    private float spawnPositionRange = 9f;
    private Vector3 positionOffset = new Vector3(0, 0, 0);

    void Start()
    {
        SpawnEnemyWave(5);
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
