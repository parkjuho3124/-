using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float chaseSpeed = 3f;
    public float slowSpeed = 1.5f;
    public float detectionRadius = 5f;

    private Transform player;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private bool isInDetectionRange = false;
    private bool hasEnteredDetection = false;

    public EnemySpawner spawner;  //  스폰매니저 연결

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);
        isInDetectionRange = distance <= detectionRadius;

        moveDirection = (player.position - transform.position).normalized;

        if (isInDetectionRange)
        {
            hasEnteredDetection = true;
        }

        if (hasEnteredDetection && !isInDetectionRange)
        {
            //  리스폰 요청하고 자신 제거
            if (spawner != null)
            {
                spawner.RequestRespawn();
            }

            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        float speed = isInDetectionRange ? slowSpeed : chaseSpeed;
        rb.velocity = moveDirection * speed;
    }

    // 디버그용 감지 반경 표시
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
