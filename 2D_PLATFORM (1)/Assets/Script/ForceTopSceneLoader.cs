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
            Debug.LogWarning("SceneTransitionManager �ν��Ͻ��� ã�� �� �����ϴ�.");
        }
    }
}
