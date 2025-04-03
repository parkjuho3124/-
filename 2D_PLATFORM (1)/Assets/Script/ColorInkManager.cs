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
            DontDestroyOnLoad(gameObject); // 씬 전환 시 유지
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
            Debug.Log($"[ColorInkManager] ColorInk {amount} 소모 → 남은 Ink: {currentInk}");
            return true;
        }
        Debug.Log("[ColorInkManager] ColorInk 부족!");
        return false;
    }

    public void AddInk(int amount)
    {
        currentInk += amount;
        Debug.Log($"[ColorInkManager] ColorInk {amount} 추가 → 현재 Ink: {currentInk}");
    }

    public int GetInk()
    {
        return currentInk;
    }
}
