using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoHome : MonoBehaviour
{ // 기지 씬 이름을 Inspector에서 설정할 수 있도록 함
    public string homeSceneName = "GameScene";

    // 플레이어 상호작용 시 호출될 메서드
    public void ReturnToHome()
    {
        Debug.Log("HomeGate 상호작용: 기지 씬으로 전환합니다.");
        SceneManager.LoadScene(homeSceneName, LoadSceneMode.Single);
    }

    // 또는, 오브젝트를 클릭했을 때 자동으로 호출하고 싶다면
    private void OnMouseDown()
    {
        ReturnToHome();
    }
}
