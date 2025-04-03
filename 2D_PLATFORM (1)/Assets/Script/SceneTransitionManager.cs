using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance;

    [Header("씬 이름")]
    public string defenseSceneName = "top";        // 탑뷰 방어 씬
    public string mainSceneName = "GameScene";     // 기지 씬
    public string explorationSceneName = "side";   // 탐험 씬

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            Scene topScene = SceneManager.GetSceneByName(defenseSceneName);
            if (!topScene.isLoaded)
            {
                Debug.Log("[SceneTransitionManager] top 씬 Additive 로드 시도");
                SceneManager.LoadScene(defenseSceneName, LoadSceneMode.Additive);
                StartCoroutine(CheckTopSceneLoaded());
            }
            else
            {
                Debug.Log("[SceneTransitionManager] top 씬은 이미 로드됨");
            }
        }
    }

    private IEnumerator CheckTopSceneLoaded()
    {
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            Debug.Log($"[로드 확인] 씬 이름: {scene.name}, isLoaded: {scene.isLoaded}");
        }

        Scene topScene = SceneManager.GetSceneByName(defenseSceneName);
        Debug.Log($"[최종 확인] top 씬 isLoaded: {topScene.isLoaded}");
    }

    public void LoadMainScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void LoadExplorationScene()
    {
        SceneManager.LoadScene(explorationSceneName, LoadSceneMode.Single);
    }

    public void GoToTopDefense()
    {
        Debug.Log("[SceneTransitionManager] GoToTopDefense 호출됨");
        StartCoroutine(WaitAndTryEnableTop());
    }

    private IEnumerator WaitAndTryEnableTop()
    {
        Debug.Log("[SceneTransitionManager] WaitAndTryEnableTop 시작");

        // top 씬이 로드되어 있는지 확인하고 없으면 로드
        Scene topScene = SceneManager.GetSceneByName(defenseSceneName);
        if (!topScene.isLoaded)
        {
            Debug.Log("[SceneTransitionManager] top 씬이 아직 로드되지 않아 Additive 로드 시작");
            SceneManager.LoadScene(defenseSceneName, LoadSceneMode.Additive);
            while (!SceneManager.GetSceneByName(defenseSceneName).isLoaded)
            {
                yield return null;
            }
            yield return new WaitForSeconds(0.2f); // 씬 준비 기다림
        }

        // TopDefenseSceneController 탐색
        TopDefenseSceneController controller = null;
        for (int i = 0; i < 40; i++)
        {
            controller = GameObject.FindObjectOfType<TopDefenseSceneController>(true);
            if (controller != null)
            {
                Debug.Log("[SceneTransitionManager] TopDefenseSceneController 찾음 → EnableTopViewMode 실행");
                controller.EnableTopViewMode();
                yield break;
            }
            yield return new WaitForSeconds(0.05f);
        }

        Debug.LogWarning("[SceneTransitionManager] 최종적으로 TopDefenseSceneController 못 찾음");
    }

    public void ReturnToMainScene()
    {
        Debug.Log("[SceneTransitionManager] ReturnToMainScene 호출됨");
        LoadMainScene(mainSceneName); // ❗ DisableTopViewMode는 외부에서 호출
    }

    public void TryLoadTopSceneIfNotLoaded()
    {
        if (!SceneManager.GetSceneByName(defenseSceneName).isLoaded)
        {
            Debug.Log("[SceneTransitionManager] 강제 top 씬 Additive 로드");
            SceneManager.LoadScene(defenseSceneName, LoadSceneMode.Additive);
        }
    }
}
