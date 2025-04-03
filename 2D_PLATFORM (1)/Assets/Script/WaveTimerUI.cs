using UnityEngine;

public class WaveTimerUI : MonoBehaviour
{
    private static WaveTimerUI instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // 다른 씬에서 온 중복 UI 제거
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
