using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    [Header("기본 능력치")]
    public int maxHealth = 100;
    public float moveSpeed = 5f;
    public int attackPower = 10;

    [Header("점프 및 채집 관련")] // ← 새로 추가된 부분
    public float jumpForce = 7f;      // 점프 높이
    public float gatherSpeed = 1f;    // 채집 속도

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 유지
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpgradeHealth(int amount) => maxHealth += amount;
    public void UpgradeSpeed(float amount) => moveSpeed += amount;
    public void UpgradeAttack(int amount) => attackPower += amount;

    // 필요하다면 이런 것도 추가 가능:
    // public void UpgradeJump(float amount) => jumpForce += amount;
    // public void UpgradeGatherSpeed(float amount) => gatherSpeed += amount;
}
