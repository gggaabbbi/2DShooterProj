using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyDino;
    [SerializeField] Vector2 minSpawnPosition, maxSpawnPosition;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
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
}
