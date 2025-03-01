using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileAutoCreate : MonoBehaviour {
    [SerializeField] GameObject topTile;
    [SerializeField] List<GameObject> tiles = new List<GameObject>();
    [SerializeField] int horizontal;
    [SerializeField] int vertical;
    [SerializeField] float spacing = 4.0f;

    private void Start() {
        horizontal = 20;
        CreateTilemap();
    }

    private void CreateTilemap() {
        Vector2 startPosition = transform.position;

        for (int i = 0; i < horizontal; i++) {
            CreateTile(startPosition, i, topTile);
        }

        for (int t = 0; t < tiles.Count; t++) {
            for (int i = 0; i < horizontal; i++) {
                CreateTile(startPosition, i, tiles[t]);
            }
        }
    }

    private void CreateTile(Vector2 startPosition, int i, GameObject tile) {
        Vector2 tilePosition = startPosition + new Vector2(i * spacing, 0);
        GameObject clone = ResourcesManager.Instance.Instantiate(tile, transform);
        clone.transform.position = tilePosition;
    }
}
