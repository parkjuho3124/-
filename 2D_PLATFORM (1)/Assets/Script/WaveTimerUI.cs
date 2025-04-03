using UnityEngine;

public class WaveTimerUI : MonoBehaviour
{
    private static WaveTimerUI instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // �ٸ� ������ �� �ߺ� UI ����
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
