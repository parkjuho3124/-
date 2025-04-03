using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownEnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    private List<GameObject> spawnedEnemies = new List<GameObject>();

    public void SpawnEnemy()
    {
        if (enemyPrefab == null || spawnPoints.Length == 0)
        {
            Debug.LogWarning("EnemyPrefab 또는 SpawnPoint가 설정되지 않았습니다.");
            return;
        }

        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        // 💡 약간의 랜덤 오프셋을 줘서 겹치지 않게 생성
        Vector2 offset = Random.insideUnitCircle.normalized * 1.2f;
        Vector3 spawnPos = spawnPoint.position + (Vector3)offset;

        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

        // 씬 전환에도 살아있게 유지
        DontDestroyOnLoad(enemy);

        spawnedEnemies.Add(enemy);
    }


    public void DestroyAllEnemies()
    {
        foreach (var enemy in spawnedEnemies)
        {
            if (enemy != null)
                Destroy(enemy);
        }

        spawnedEnemies.Clear();
    }
    public void SpawnEnemies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            SpawnEnemy(); // 기존에 있던 적 생성 함수
        }
    }

}
