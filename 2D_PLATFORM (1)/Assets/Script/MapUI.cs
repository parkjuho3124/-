using UnityEngine;
using UnityEngine.SceneManagement;

public class MapUI : MonoBehaviour
{
    public void SelectZone(string side)
    {
        if (!string.IsNullOrEmpty(side))
        {
            Debug.Log("�� ��ȯ �õ�: " + side);
            Time.timeScale = 1f;
            SceneManager.LoadScene(side);
        }
        else
        {
            Debug.LogWarning("�� �̸��� ��� ����!");
        }
    }

}
