using UnityEngine;
using UnityEngine.SceneManagement;

public class CannonOrbit : MonoBehaviour
{
    public Transform bunkerCenter;      // 벙커 중심
    public float radius = 3f;           // 벙커 외곽 거리
    public GameObject bulletPrefab;     // 총알 프리팹
    public float bulletSpeed = 10f;

    void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f; // Z 보정

        Vector2 dir = (mouseWorldPos - bunkerCenter.position).normalized;

        // 대포 위치를 벙커 중심 기준 반지름 거리로 설정
        transform.position = bunkerCenter.position + (Vector3)(dir * radius);

        // 대포 회전 (마우스를 향해)
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if (Input.GetMouseButtonDown(1))
        {
            Fire(dir);
        }
    }

    void Fire(Vector2 dir)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

        // Rigidbody 물리 적용
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = dir * bulletSpeed;
        }

        // 🔥 생성된 총알을 top 씬으로 이동시키기
        Scene topScene = SceneManager.GetSceneByName("top");
        if (topScene.IsValid() && topScene.isLoaded)
        {
            SceneManager.MoveGameObjectToScene(bullet, topScene);
        }
        else
        {
            Debug.LogWarning("[CannonOrbit] top 씬이 아직 로드되지 않음!");
        }
    }
}
