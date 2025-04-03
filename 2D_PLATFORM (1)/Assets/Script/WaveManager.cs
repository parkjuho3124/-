using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance;

    public float waveDelay = 15f; // 다음 웨이브까지 대기 시간
    private float currentTime = 0f;
    public int waveCount = 0;
    public int killCount = 0;

    private bool waveInProgress = false;
    private bool waitForNextWave = false;

    private TextMeshProUGUI waveTimerText;


    void Start()
    {
        Debug.Log("[WaveManager] Start() → 첫 웨이브를 " + waveDelay + "초 뒤에 시작");
        currentTime = waveDelay;
        waitForNextWave = true;
    }


    void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Update()
    {
        if (waitForNextWave)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerText();

            if (currentTime <= 0f)
            {
                waitForNextWave = false;
                StartCoroutine(SpawnWaveCoroutine());
            }
        }
    }

    IEnumerator SpawnWaveCoroutine()
    {
        waveCount++;
        killCount = 0;
        waveInProgress = true;

        Debug.Log($"[WaveManager] 웨이브 {waveCount} 시작!");

        // top 씬 로드 확인
        Scene topScene = SceneManager.GetSceneByName("top");
        if (!topScene.isLoaded)
        {
            SceneManager.LoadScene("top", LoadSceneMode.Additive);
            while (!SceneManager.GetSceneByName("top").isLoaded)
                yield return null;
        }

        yield return new WaitForSeconds(0.1f);

        TopDownEnemySpawner spawner = GameObject.FindObjectOfType<TopDownEnemySpawner>(true);
        if (spawner != null)
        {
            int enemyCount = waveCount * 10;
            spawner.SpawnEnemies(enemyCount);
            Debug.Log($"[WaveManager] 적 {enemyCount}마리 생성됨");
        }
        else
        {
            Debug.LogWarning("[WaveManager] TopDownEnemySpawner 못 찾음");
        }
    }

    public void AddKill()
    {
        killCount++;
        Debug.Log($"[WaveManager] 킬 카운트: {killCount} / 목표: {waveCount * 10}");

        if (killCount >= waveCount * 10 && waveInProgress)
        {
            Debug.Log($"[WaveManager] 킬 조건 달성! 웨이브 {waveCount} 완료");
            waveInProgress = false;
            waitForNextWave = true;
            currentTime = waveDelay;
        }
    }


    void UpdateTimerText()
    {
        if (waveTimerText != null)
        {
            if (waitForNextWave)
                waveTimerText.text = $"NextWave: {Mathf.CeilToInt(currentTime)}";
            else
                waveTimerText.text = $"Left: {waveCount}";
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        var foundText = GameObject.Find("WaveTimerText");
        if (foundText != null)
        {
            waveTimerText = foundText.GetComponent<TextMeshProUGUI>();
        }
    }
}
