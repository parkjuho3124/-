using UnityEngine;

public class UpgradeConsole : MonoBehaviour
{
    public GameObject upgradeUI;

    public void OpenUI()
    {
        Debug.Log("���׷��̵� �ܼ� ����!");
        upgradeUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
