using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyDino;
    [SerializeField] GameObject enemyBear;
    [SerializeField] Vector2 minSpawnPosition, maxSpawnPosition;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnBoss());
    }



    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            float xPosition = Random.Range(minSpawnPosition.x, maxSpawnPosition.x);
            float yPosition = Random.Range(minSpawnPosition.y, maxSpawnPosition.y);
            Instantiate(enemyDino, new Vector2(xPosition, yPosition), Quaternion.identity);
        }
    }

    private IEnumerator SpawnBoss()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(10f);
            float xPosition = Random.Range(minSpawnPosition.x, maxSpawnPosition.x);
            float yPosition = Random.Range(minSpawnPosition.y, maxSpawnPosition.y);
            Instantiate(enemyBear, new Vector2(xPosition, yPosition), Quaternion.identity);
        }
    }
}
