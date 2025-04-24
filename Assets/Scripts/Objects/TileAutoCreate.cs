using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;

public class TileAutoCreate : MonoBehaviour {
    [SerializeField] GameObject topTile;
    [SerializeField] List<GameObject> tiles = new List<GameObject>();

    [SerializeField] int horizontal;
    [SerializeField] int vertical;
    [SerializeField] float spacing;

    private void Start() {
        horizontal = 30;
        vertical = 20;
        spacing = 1.0f;

        TileManager.Instance.RightX = horizontal + TileManager.Instance.LeftX - 1;
        CreateTilemap();
        ArtifactBurial();
    }

    private void CreateTilemap() {
        Vector2 startPosition = transform.position;
        int line = 0;
        int y = 0;

        for (int i = 0; i < horizontal; i++)
            CreateTile(startPosition, i, line, i, y, topTile);
        y--;

        for (int t = 0; t < tiles.Count; t++) {
            TileManager.Instance.TierY.Add(y);
            for (int v = 0; v < vertical; v++) {
                for (int h = 0; h < horizontal; h++)
                    CreateTile(startPosition, h, line, h, y, tiles[t]);
                line--;
                y--;
            }
        }

        TileManager.Instance.TierY.Add(y);
    }

    private void CreateTile(Vector2 startPosition, int h, int v, int x, int y, GameObject tile) {
        Vector2 tilePosition = startPosition + new Vector2(h * spacing, v);
        GameObject clone = ResourcesManager.Instance.Instantiate(tile, transform);
        clone.transform.position = tilePosition;

        TileData tileData = new TileData(2, 1, x, y);

        TileManager.Instance.TileDictionary.Add(clone, tileData);
    }

    private void ArtifactBurial() {
        foreach (var artifact in ArtifactManager.Instance.Artifacts) {
            float minX = TileManager.Instance.LeftX;
            float maxX = TileManager.Instance.RightX;
            float minY = TileManager.Instance.TierY[artifact.Value.data.tier - 1];
            float maxY = TileManager.Instance.TierY[artifact.Value.data.tier] + 1;

            float x = minX + UnityEngine.Random.Range(0, (int)(maxX - minX + 1));
            float y = minY + UnityEngine.Random.Range(0, (int)(maxY - minY + 1));

            artifact.Key.transform.position = new Vector2(x, y + 0.5f);
            artifact.Key.SetActive(true);
        }
    }
}
