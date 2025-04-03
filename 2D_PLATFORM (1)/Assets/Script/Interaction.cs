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
        // �÷��̾� �������� ����ĳ��Ʈ
        Vector2 direction = Vector2.right * transform.localScale.x;
        Vector2 origin = (Vector2)transform.position + direction * 0.5f;
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, interactionRange);

        if (hit.collider != null)
        {
            GameObject target = hit.collider.gameObject;
            Debug.Log("��ȣ�ۿ� ��� �߰�: " + target.name + " / �±�: " + target.tag);

            // Upgrade �±� ó��
            if (target.CompareTag("Upgrade"))
            {
                UpgradeConsole upgradeConsole = target.GetComponent<UpgradeConsole>();
                if (upgradeConsole != null)
                {
                    upgradeConsole.OpenUI();
                }
                else
                {
                    Debug.LogWarning("UpgradeConsole ������Ʈ�� �����ϴ�: " + target.name);
                }
            }
            // Gate �±� ó�� (Ž�� ������ �̵�)
            else if (target.CompareTag("Gate"))
            {
                // ExplorationGate ��ũ��Ʈ�� ���� ��� ����
                ExplorationGate gate = target.GetComponent<ExplorationGate>();
                if (gate != null)
                {
                    gate.EnterExploration();
                }
                else
                {
                    Debug.LogWarning("ExplorationGate ������Ʈ�� �����ϴ�: " + target.name);
                }
            }
            // Transmitter �±� ó��
            else if (target.CompareTag("Transmitter"))
            {
                InkTransmitter transmitter = target.GetComponent<InkTransmitter>();
                if (transmitter != null)
                {
                    transmitter.Transmit();
                }
                else
                {
                    Debug.LogWarning("InkTransmitter ������Ʈ�� �����ϴ�: " + target.name);
                }
            }
            // DefenseTerminal �±� ó��
            else if (target.CompareTag("Topmove"))
            {
                // ���÷� TopDownDefense ������ ��ȯ
                SceneTransitionManager.Instance.GoToTopDefense();
            }
            // HomeGate �±� ó��
            else if (target.CompareTag("HomeGate"))
            {
                SceneManager.LoadScene("GameScene"); // GameScene���� ��ȯ
            }
        }
        else
        {
            Debug.Log("��ȣ�ۿ� ���� ���� ��� ����");
        }
    }
}
