using UnityEngine;
using TMPro;

public class BaseHealthUI : MonoBehaviour
{
    public static BaseHealthUI Instance;

    public TextMeshProUGUI healthText;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateHealth(int current, int max)
    {
        if (healthText != null)
        {
            healthText.text = $"Base Health: {current}/{max}";
        }
    }
}
