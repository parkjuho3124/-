using UnityEngine;
using UnityEngine.SceneManagement;

public class TopSceneOffsetApplier : MonoBehaviour
{
    public Vector3 offset = new Vector3(100f, 0f, 0f); // 오른쪽으로 100 이동
    private static bool offsetApplied = false;

    void Start()
    {
        // top 씬이 처음 로드됐을 때만 한 번 적용
        Scene currentScene = gameObject.scene;
        if (currentScene.name == "top" && !offsetApplied)
        {
            ApplyOffsetToRootObjects(currentScene);
            offsetApplied = true;
        }
    }

    void ApplyOffsetToRootObjects(Scene scene)
    {
        GameObject[] rootObjects = scene.GetRootGameObjects();
        foreach (var obj in rootObjects)
        {
            obj.transform.position += offset;
        }

        Debug.Log($"[TopSceneOffset] top 씬 루트 오브젝트 오프셋 적용: {offset}");
    }
}
