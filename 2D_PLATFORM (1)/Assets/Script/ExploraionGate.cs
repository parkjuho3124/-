using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplorationGate : MonoBehaviour
{
    public string explorationSceneName = "ExplorationScene";

    public void EnterExploration()
    {
        Debug.Log("Ž�� �������� �̵�!");
        SceneManager.LoadScene(explorationSceneName);
    }
}
