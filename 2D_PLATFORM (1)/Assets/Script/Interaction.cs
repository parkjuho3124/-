using UnityEngine;
using UnityEngine.SceneManagement;

public class Interaction : MonoBehaviour
{
    public float interactionRange = 1.5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    void TryInteract()
    {
        // 플레이어 앞쪽으로 레이캐스트
        Vector2 direction = Vector2.right * transform.localScale.x;
        Vector2 origin = (Vector2)transform.position + direction * 0.5f;
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, interactionRange);

        if (hit.collider != null)
        {
            GameObject target = hit.collider.gameObject;
            Debug.Log("상호작용 대상 발견: " + target.name + " / 태그: " + target.tag);

            // Upgrade 태그 처리
            if (target.CompareTag("Upgrade"))
            {
                UpgradeConsole upgradeConsole = target.GetComponent<UpgradeConsole>();
                if (upgradeConsole != null)
                {
                    upgradeConsole.OpenUI();
                }
                else
                {
                    Debug.LogWarning("UpgradeConsole 컴포넌트가 없습니다: " + target.name);
                }
            }
            // Gate 태그 처리 (탐험 씬으로 이동)
            else if (target.CompareTag("Gate"))
            {
                // ExplorationGate 스크립트가 있을 경우 실행
                ExplorationGate gate = target.GetComponent<ExplorationGate>();
                if (gate != null)
                {
                    gate.EnterExploration();
                }
                else
                {
                    Debug.LogWarning("ExplorationGate 컴포넌트가 없습니다: " + target.name);
                }
            }
            // Transmitter 태그 처리
            else if (target.CompareTag("Transmitter"))
            {
                InkTransmitter transmitter = target.GetComponent<InkTransmitter>();
                if (transmitter != null)
                {
                    transmitter.Transmit();
                }
                else
                {
                    Debug.LogWarning("InkTransmitter 컴포넌트가 없습니다: " + target.name);
                }
            }
            // DefenseTerminal 태그 처리
            else if (target.CompareTag("Topmove"))
            {
                // 예시로 TopDownDefense 씬으로 전환
                SceneTransitionManager.Instance.GoToTopDefense();
            }
            // HomeGate 태그 처리
            else if (target.CompareTag("HomeGate"))
            {
                SceneManager.LoadScene("GameScene"); // GameScene으로 전환
            }
        }
        else
        {
            Debug.Log("상호작용 범위 내에 대상 없음");
        }
    }
}
