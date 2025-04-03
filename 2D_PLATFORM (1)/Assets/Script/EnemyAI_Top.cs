using UnityEngine;

public class EnemyAI_Top : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float attackRange = 0.5f;
    public float attackCooldown = 1f;
    public int damage = 10;

    private Transform baseTarget;
    private Animator anim;
    private float lastAttackTime;
    private bool isDead = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Die()
    {
        if (isDead) return;
        isDead = true;

        Debug.Log("[Enemy] 사망 처리됨!");
        WaveManager.Instance?.AddKill();
        Destroy(gameObject);
    }

    void Update()
    {
        // 기지를 못 찾았으면 계속 탐색
        if (baseTarget == null)
        {
            GameObject baseObj = GameObject.FindGameObjectWithTag("Base");
            if (baseObj != null)
            {
                baseTarget = baseObj.transform;
                Debug.Log($"[EnemyAI_Top] 기지 발견 → {baseTarget.name}");
            }
            else
            {
                // 아직 기지 없으면 기다림
                return;
            }
        }

        float distance = Vector2.Distance(transform.position, baseTarget.position);

        if (distance > attackRange)
        {
            // 기지로 이동
            Vector2 dir = (baseTarget.position - transform.position).normalized;
            transform.position += (Vector3)(dir * moveSpeed * Time.deltaTime);
        }
        else
        {
            // 공격
            if (Time.time - lastAttackTime > attackCooldown)
            {
                if (anim != null)
                    anim.SetTrigger("Attack");

                if (BaseHealth.Instance != null)
                {
                    BaseHealth.Instance.TakeDamage(damage);
                    Debug.Log($"[EnemyAI_Top] {gameObject.name} → 기지를 공격함! 데미지: {damage}");
                }

                lastAttackTime = Time.time;
            }
        }

    }

}
