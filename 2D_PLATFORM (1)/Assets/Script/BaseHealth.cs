using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    public static BaseHealth Instance;

    public int maxHealth = 100;
    public int currentHealth;

    void Awake()
    {
        if (Instance == null) Instance = this;
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("[기지] 데미지 받음: " + amount + " → 현재 체력: " + currentHealth);

        // ✅ UI 업데이트
        BaseHealthUI.Instance?.UpdateHealth(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("[기지] 파괴됨!");
            // TODO: 게임오버 처리
        }
    }

}

