using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 2f;
    private bool hasHit = false;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Enemy가 아니면 무시
        if (!other.CompareTag("Enemy")) return;

        // Enemy인데 hasHit이 true면 무시
        if (hasHit) return;

        hasHit = true;

        Debug.Log("[Bullet] Enemy 적중! → 적 제거 & 킬카운트 증가");

        // 킬카운트 올리기
        if (WaveManager.Instance != null)
        {
            WaveManager.Instance.AddKill();
        }

        Destroy(other.gameObject); // 적 제거
        Destroy(gameObject);       // 총알 제거
    }
}
