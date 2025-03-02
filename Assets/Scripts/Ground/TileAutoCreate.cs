using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;

public class TileAutoCreate : MonoBehaviour {
    [SerializeField] GameObject topTile;
    [SerializeField] List<GameObject> tiles = new List<GameObject>();
    [SerializeField] int horizontal;
    [SerializeField] int vertical;
    [SerializeField] float spacing = 4.0f;

    private void Start() {
        horizontal = 30;
        vertical = 10;
        CreateTilemap();
    }

    private void CreateTilemap() {
        Vector2 startPosition = transform.position;
        int line = 0;

        for (int i = 0; i < horizontal; i++) 
            CreateTile(startPosition, i, line, topTile);

        for (int t = 0; t < tiles.Count; t++) {
            for (int v = 0; v < vertical; v++) {
                for (int h = 0; h < horizontal; h++)
                    CreateTile(startPosition, h, line, tiles[t]);
                line--;
            }
            line++;
        }
    }

    private void CreateTile(Vector2 startPosition, int h, int v, GameObject tile) {
        Vector2 tilePosition = startPosition + new Vector2(h * spacing, v);
        GameObject clone = ResourcesManager.Instance.Instantiate(tile, transform);
        clone.transform.position = tilePosition;

        TileData tileData = new TileData(10, 1);

        TileManager.Instance.TileDictionary.Add(clone, tileData);
    }
}
