using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using TMPro;

public class TileBreakerByClick : MonoBehaviour
{
    public Tilemap foregroundTilemap;     // 일반 타일 (위)
    public Tilemap targetTilemap;         // 타겟 타일 (아래)

    public TileBase crackedTile;
    public TileBase redTile;
    public TileBase redCrackedTile;
    public TileBase targetTile;

    public float breakRadius = 1.0f;
    public Animator miningAnim;

    public int colorInk = 0;
    public int targetInk = 0;

    public TextMeshProUGUI colorInkText;
    public TextMeshProUGUI targetInkText;

    private Vector3Int lastClickedTile;
    private bool firstClick = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;

            Vector3Int cellPos = foregroundTilemap.WorldToCell(mouseWorldPos);
            Vector3 cellWorldCenter = foregroundTilemap.GetCellCenterWorld(cellPos);
            float dist = Vector3.Distance(transform.position, cellWorldCenter);
            if (dist > breakRadius) return;

            // 애니메이션 (탐험 씬에서만)
            if (SceneManager.GetActiveScene().name == "side" && miningAnim != null)
            {
                miningAnim.SetTrigger("Mine");
            }

            // 1️⃣ 먼저 foreground 타일맵을 확인
            TileBase currentTile = foregroundTilemap.GetTile(cellPos);

            if (currentTile != null)
            {
                // 균열된 타일 → 파괴
                if (currentTile == crackedTile || currentTile == redCrackedTile)
                {
                    foregroundTilemap.SetTile(cellPos, null);
                    firstClick = false;

                    if (currentTile == redCrackedTile)
                    {
                        colorInk++;
                        if (colorInkText != null)
                            colorInkText.text = "ColorInk: " + colorInk;
                        Debug.Log("빨간 타일 파괴됨 - ColorInk +1");
                    }

                    return; // ❌ 타겟 타일은 무시!
                }

                // 첫 번째 클릭 → 균열로 변경
                firstClick = true;
                lastClickedTile = cellPos;

                if (currentTile == redTile)
                {
                    foregroundTilemap.SetTile(cellPos, redCrackedTile);
                    Debug.Log("빨간 타일 → 균열");
                }
                else
                {
                    foregroundTilemap.SetTile(cellPos, crackedTile);
                    Debug.Log("일반 타일 → 균열");
                }

                return;
            }

            // 2️⃣ foreground가 비어있을 경우 → 타겟 타일 체크
            TileBase target = targetTilemap.GetTile(cellPos);

            if (target == targetTile)
            {
                targetTilemap.SetTile(cellPos, null);
                targetInk++;

                if (targetInkText != null)
                    targetInkText.text = "TargetInk: " + targetInk;

                Debug.Log("타겟 타일 파괴됨 - TargetInk +1");
            }
        }
    }
}
