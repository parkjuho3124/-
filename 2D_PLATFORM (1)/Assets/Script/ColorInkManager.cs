using UnityEngine;

public class ColorInkManager : MonoBehaviour
{
    public static ColorInkManager Instance;

    public int currentInk = 0;

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

    public bool SpendInk(int amount)
    {
        if (currentInk >= amount)
        {
            currentInk -= amount;
            Debug.Log($"[ColorInkManager] ColorInk {amount} �Ҹ� �� ���� Ink: {currentInk}");
            return true;
        }
        Debug.Log("[ColorInkManager] ColorInk ����!");
        return false;
    }

    public void AddInk(int amount)
    {
        currentInk += amount;
        Debug.Log($"[ColorInkManager] ColorInk {amount} �߰� �� ���� Ink: {currentInk}");
    }

    public int GetInk()
    {
        return currentInk;
    }
}
