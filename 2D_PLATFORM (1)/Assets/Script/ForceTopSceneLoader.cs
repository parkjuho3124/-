using UnityEngine;

public class ForceTopSceneLoader : MonoBehaviour
{
    void Start()
    {
        if (SceneTransitionManager.Instance != null)
        {
            SceneTransitionManager.Instance.TryLoadTopSceneIfNotLoaded();
        }
        else
        {
            Debug.LogWarning("SceneTransitionManager 인스턴스를 찾을 수 없습니다.");
        }
    }
}
