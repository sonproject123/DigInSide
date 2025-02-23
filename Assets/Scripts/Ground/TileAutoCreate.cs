using UnityEngine;
using UnityEngine.Tilemaps;

public class TileAutoCreate : MonoBehaviour {
    [SerializeField] Tilemap tilemap; // Ÿ�ϸ� ������Ʈ
    [SerializeField] TileBase tilePrefab; // ����� Ÿ�� ������

    private void Start() {
        CreateTilemap();
    }

    private void CreateTilemap() {
        // Ÿ�ϸ��� ũ�� ���� (��: 10x10)
        int width = 10;
        int height = 10;

        // Ÿ���� �������� �߰�
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                Vector3Int tilePosition = new Vector3Int(x, y, 0);
                tilemap.SetTile(tilePosition, tilePrefab);
            }
        }
    }
}
