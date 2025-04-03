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
            Debug.Log("체력 증가! 현재 체력: " + playerStats.maxHealth);
        }
        else
        {
            Debug.Log("ColorInk 부족! 체력 업그레이드 실패");
        }
    }

    public void IncreaseSpeed()
    {
        if (ColorInkManager.Instance.SpendInk(speedUpgradeCost))
        {
            playerStats.moveSpeed += 1f;
            Debug.Log("이동속도 증가! 현재 속도: " + playerStats.moveSpeed);
        }
        else
        {
            Debug.Log("ColorInk 부족! 속도 업그레이드 실패");
        }
    }

    public void IncreaseGatherSpeed()
    {
        if (ColorInkManager.Instance.SpendInk(gatherSpeedUpgradeCost))
        {
            playerStats.gatherSpeed += 0.5f;
            Debug.Log("채집속도 증가! 현재 속도: " + playerStats.gatherSpeed);
        }
        else
        {
            Debug.Log("ColorInk 부족! 채집속도 업그레이드 실패");
        }
    }

    public void CloseUpgrade()
    {
        upgradePanel.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("업그레이드 UI 닫힘");
    }
}
