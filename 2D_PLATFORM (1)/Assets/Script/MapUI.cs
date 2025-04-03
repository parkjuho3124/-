using UnityEngine;
using UnityEngine.SceneManagement;

public class MapUI : MonoBehaviour
{
    public void SelectZone(string side)
    {
        if (!string.IsNullOrEmpty(side))
        {
            Debug.Log("씬 전환 시도: " + side);
            Time.timeScale = 1f;
            SceneManager.LoadScene(side);
        }
        else
        {
            Debug.LogWarning("씬 이름이 비어 있음!");
        }
    }

}
