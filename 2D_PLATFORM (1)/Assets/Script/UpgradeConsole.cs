using UnityEngine;

public class UpgradeConsole : MonoBehaviour
{
    public GameObject upgradeUI;

    public void OpenUI()
    {
        Debug.Log("업그레이드 콘솔 열림!");
        upgradeUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
