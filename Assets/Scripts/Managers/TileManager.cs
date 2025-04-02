using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

[Serializable]
public struct TileData {
    public float maxHp;
    public float hp;
    public int price;
    public int x;
    public int y;

    public TileData(float maxHp, int price, int x, int y) {
        this.maxHp = maxHp;
        this.hp = maxHp;
        this.price = price;
        this.x = x;
        this.y = y;
    }
}

public struct TileUIComponent {
    public Slider slider;
}

public class TileManager : Singleton<TileManager> {
    float leftX, rightX, midY;
    List<int> tierY = new List<int>();

    Dictionary<GameObject, TileData> tiles = new Dictionary<GameObject, TileData>();
    Dictionary<GameObject, GameObject> tileUIs = new Dictionary<GameObject, GameObject>();
    Dictionary<GameObject, TileUIComponent> tileUIComponents = new Dictionary<GameObject, TileUIComponent>();

    private new void Awake() {
        base.Awake();
        leftX = -7.5f;
        midY = 3.5f;
    }

    public void TileDamage(GameObject tile, float damage) {
        tiles.TryGetValue(tile, out TileData tileData);
        GameObject tileUI = null;

        if (!tileUIs.TryGetValue(tile, out tileUI)) {
            tileUI = ObjectManager.Instance.UseObject("TILE_UI");
            tileUI.transform.position = new Vector2(tileData.x + leftX, tileData.y + midY);
            Transform tileUICanvas = tileUI.transform.Find("Canvas");

            TileUIComponent tileUIComponentTemp;
            tileUIComponentTemp.slider = tileUICanvas.transform.Find("Slider").GetComponent<Slider>();

            tileUIs.Add(tile, tileUI);
            tileUIComponents.Add(tileUI, tileUIComponentTemp);
        }

        tileUIComponents.TryGetValue(tileUI, out TileUIComponent tileUIComponent);

        tileData.hp -= damage;
        tileUIComponent.slider.maxValue = tileData.maxHp;
        tileUIComponent.slider.value = tileData.hp;

        tiles[tile] = tileData;
        tileUIComponents[tileUI] = tileUIComponent;

        if (tileData.hp <= 0.0) {
            tiles.Remove(tile);
            tileUIs.Remove(tile);
            tileUIComponents.Remove(tileUI);

            Destroy(tile);
            ObjectManager.Instance.ReturnObject(tileUI, "TILE_UI");
        }
    }

    public float LeftX { get { return leftX; } set { leftX = value; } }
    public float RightX { get { return rightX; } set { rightX = value; } }
    public float MidY { get { return midY; } set { midY = value; } }
    public List<int> TierY { get { return tierY; } set { tierY = value; } }
    public Dictionary<GameObject, TileData> TileDictionary { get { return tiles; } set { tiles = value; } }
}
