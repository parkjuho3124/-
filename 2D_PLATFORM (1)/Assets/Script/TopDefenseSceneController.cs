using UnityEngine;
using System.Collections;

public class TopDefenseSceneController : MonoBehaviour
{
    public Camera topCamera;
    public GameObject topUI;
    public GameObject topOnlyGroup;

    private Camera mainCam;

    // 탑뷰 모드 여부 확인용
    public bool isTopView = false;

    void Awake()
    {
        mainCam = Camera.main;
    }

    private void OnEnable()
    {
        Debug.Log($"[TopInit] OnEnable - 현재 씬: {gameObject.scene.name}");

        if (topOnlyGroup != null)
        {
            topOnlyGroup.SetActive(false);
            Debug.Log("[TopInit] topOnlyGroup OFF");
        }

        if (mainCam != null)
        {
            mainCam.enabled = true;
            Debug.Log("[TopInit] MainCamera 다시 활성화");
        }

        if (topCamera != null)
        {
            topCamera.gameObject.SetActive(true);
            topCamera.enabled = false;
            Debug.Log($"[TopInit] 카메라 SetActive: {topCamera.gameObject.activeSelf}, Enabled: {topCamera.enabled}");
        }

        if (topUI != null && topUI.name != "WaveTimerUI")
        {
            topUI.SetActive(false);
            Debug.Log("[TopInit] topUI OFF (WaveTimer 제외)");
        }

        isTopView = false;
    }

    public void EnableTopViewMode()
    {
        Debug.Log("[Top] EnableTopViewMode 호출됨");
        StartCoroutine(DelayedEnableCamera());
    }

    private IEnumerator DelayedEnableCamera()
    {
        yield return new WaitForSeconds(0.1f);

        if (mainCam != null)
            mainCam.enabled = false;

        if (topCamera != null)
        {
            topCamera.gameObject.SetActive(true);
            topCamera.enabled = true;
            Debug.Log("[Top] 카메라 ON");
        }

        if (topUI != null)
        {
            topUI.SetActive(true);
            Debug.Log("[Top] UI ON");
        }

        if (topOnlyGroup != null)
        {
            topOnlyGroup.SetActive(true);
            Debug.Log("[Top] topOnlyGroup ON");
        }

        isTopView = true;
    }

    public void DisableTopViewMode()
    {
        if (mainCam != null)
            mainCam.enabled = true;

        if (topCamera != null)
        {
            topCamera.enabled = false;
            Debug.Log("[Top] 카메라 OFF");
        }

        if (topUI != null && topUI.name != "WaveTimerUI")
        {
            topUI.SetActive(false);
            Debug.Log("[Top] UI OFF");
        }

        if (topOnlyGroup != null)
        {
            topOnlyGroup.SetActive(false);
            Debug.Log("[Top] topOnlyGroup OFF");
        }

        isTopView = false;
    }
}
