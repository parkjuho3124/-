using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;         //  스폰할 적 프리팹
    public GameObject[] spawnPoints;       //  빈 오브젝트로 된 위치 배열
    public float respawnDelay = 3f;

    private bool isRespawning = false;

    void Start()
    {
        SpawnEnemy(); // 게임 시작 시 한 번 스폰
    }

    public void RequestRespawn()
    {
        if (!isRespawning)
        {
            StartCoroutine(RespawnCoroutine());
        }
    }

    IEnumerator RespawnCoroutine()
    {
        isRespawning = true;
        yield return new WaitForSeconds(respawnDelay);
        SpawnEnemy();
        isRespawning = false;
    }

    void SpawnEnemy()
    {
        if (spawnPoints.Length == 0 || enemyPrefab == null)
        {
            Debug.LogWarning("스폰포인트 또는 프리팹이 없습니다.");
            return;
        }

        int rand = Random.Range(0, spawnPoints.Length);
        Vector3 spawnPos = spawnPoints[rand].transform.position;

        GameObject newEnemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        newEnemy.GetComponent<EnemyAI>().spawner = this; //  스폰매니저 연결
    }
}
