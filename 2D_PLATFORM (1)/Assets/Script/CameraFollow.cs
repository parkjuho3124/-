using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("ī�޶� ���󰡱�")]
    public Transform target;
    public Vector3 offset = new Vector3(0f, 0f, -10f);
    public float smoothSpeed = 5f;

    [Header("�� ����")]
    public float zoomSpeed = 5f;
    public float minZoom = 3f;
    public float maxZoom = 10f;

    [Header("ī�޶� �̵� ����")]
    public Vector2 minPosition; // (�ּ� X, Y)
    public Vector2 maxPosition; // (�ִ� X, Y)

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void LateUpdate()
    {
        FollowTarget();
        HandleZoom();
    }

    void FollowTarget()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

            // ī�޶� ��ġ ���� ����
            float clampedX = Mathf.Clamp(smoothedPosition.x, minPosition.x, maxPosition.x);
            float clampedY = Mathf.Clamp(smoothedPosition.y, minPosition.y, maxPosition.y);

            transform.position = new Vector3(clampedX, clampedY, smoothedPosition.z);
        }
    }

    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0f)
        {
            cam.orthographicSize -= scroll * zoomSpeed;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);
        }
    }
}
