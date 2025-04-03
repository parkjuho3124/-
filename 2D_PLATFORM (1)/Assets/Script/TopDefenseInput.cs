using UnityEngine;

public class TopDefenseInput : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            var controller = GameObject.FindObjectOfType<TopDefenseSceneController>(true);
            if (controller != null && controller.isTopView)
            {
                controller.DisableTopViewMode();
                SceneTransitionManager.Instance.ReturnToMainScene();
            }
        }
    }
}
