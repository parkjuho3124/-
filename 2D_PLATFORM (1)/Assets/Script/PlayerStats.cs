using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    [Header("�⺻ �ɷ�ġ")]
    public int maxHealth = 100;
    public float moveSpeed = 5f;
    public int attackPower = 10;

    [Header("���� �� ä�� ����")] // �� ���� �߰��� �κ�
    public float jumpForce = 7f;      // ���� ����
    public float gatherSpeed = 1f;    // ä�� �ӵ�

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �� ����
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpgradeHealth(int amount) => maxHealth += amount;
    public void UpgradeSpeed(float amount) => moveSpeed += amount;
    public void UpgradeAttack(int amount) => attackPower += amount;

    // �ʿ��ϴٸ� �̷� �͵� �߰� ����:
    // public void UpgradeJump(float amount) => jumpForce += amount;
    // public void UpgradeGatherSpeed(float amount) => gatherSpeed += amount;
}
