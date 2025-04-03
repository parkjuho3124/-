using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoHome : MonoBehaviour
{ // ���� �� �̸��� Inspector���� ������ �� �ֵ��� ��
    public string homeSceneName = "GameScene";

    // �÷��̾� ��ȣ�ۿ� �� ȣ��� �޼���
    public void ReturnToHome()
    {
        Debug.Log("HomeGate ��ȣ�ۿ�: ���� ������ ��ȯ�մϴ�.");
        SceneManager.LoadScene(homeSceneName, LoadSceneMode.Single);
    }

    // �Ǵ�, ������Ʈ�� Ŭ������ �� �ڵ����� ȣ���ϰ� �ʹٸ�
    private void OnMouseDown()
    {
        ReturnToHome();
    }
}
