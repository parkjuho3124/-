using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public PlayerStats playerStats;
    public GameObject upgradePanel;

    public int healthUpgradeCost = 5;
    public int speedUpgradeCost = 5;
    public int gatherSpeedUpgradeCost = 3;

    public void IncreaseHealth()
    {
        if (ColorInkManager.Instance.SpendInk(healthUpgradeCost))
        {
            playerStats.maxHealth += 20;
            Debug.Log("ü�� ����! ���� ü��: " + playerStats.maxHealth);
        }
        else
        {
            Debug.Log("ColorInk ����! ü�� ���׷��̵� ����");
        }
    }

    public void IncreaseSpeed()
    {
        if (ColorInkManager.Instance.SpendInk(speedUpgradeCost))
        {
            playerStats.moveSpeed += 1f;
            Debug.Log("�̵��ӵ� ����! ���� �ӵ�: " + playerStats.moveSpeed);
        }
        else
        {
            Debug.Log("ColorInk ����! �ӵ� ���׷��̵� ����");
        }
    }

    public void IncreaseGatherSpeed()
    {
        if (ColorInkManager.Instance.SpendInk(gatherSpeedUpgradeCost))
        {
            playerStats.gatherSpeed += 0.5f;
            Debug.Log("ä���ӵ� ����! ���� �ӵ�: " + playerStats.gatherSpeed);
        }
        else
        {
            Debug.Log("ColorInk ����! ä���ӵ� ���׷��̵� ����");
        }
    }

    public void CloseUpgrade()
    {
        upgradePanel.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("���׷��̵� UI ����");
    }
}
