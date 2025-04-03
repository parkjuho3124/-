using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplorationGate : MonoBehaviour
{
    public string explorationSceneName = "ExplorationScene";

    public void EnterExploration()
    {
        Debug.Log("탐험 지역으로 이동!");
        SceneManager.LoadScene(explorationSceneName);
    }
}
