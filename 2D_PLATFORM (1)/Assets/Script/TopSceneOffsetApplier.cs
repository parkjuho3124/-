using UnityEngine;
using UnityEngine.SceneManagement;

public class TopSceneOffsetApplier : MonoBehaviour
{
    public Vector3 offset = new Vector3(100f, 0f, 0f); // ���������� 100 �̵�
    private static bool offsetApplied = false;

    void Start()
    {
        // top ���� ó�� �ε���� ���� �� �� ����
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

        Debug.Log($"[TopSceneOffset] top �� ��Ʈ ������Ʈ ������ ����: {offset}");
    }
}
