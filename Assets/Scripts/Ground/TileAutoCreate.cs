using UnityEngine;
using UnityEngine.Tilemaps;

public class TileAutoCreate : MonoBehaviour {
    [SerializeField] Tilemap tilemap; // 타일맵 컴포넌트
    [SerializeField] TileBase tilePrefab; // 사용할 타일 프리팹

    private void Start() {
        CreateTilemap();
    }

    private void CreateTilemap() {
        // 타일맵의 크기 설정 (예: 10x10)
        int width = 10;
        int height = 10;

        // 타일을 동적으로 추가
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                Vector3Int tilePosition = new Vector3Int(x, y, 0);
                tilemap.SetTile(tilePosition, tilePrefab);
            }
        }
    }
}
