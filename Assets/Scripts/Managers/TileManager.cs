using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct TileData {
    public float maxHp;
    public float hp;
    public int price;

    public TileData(float maxHp, int price) {
        this.maxHp = maxHp;
        this.hp = maxHp;
        this.price = price;
    }
}

public struct TileUIComponent {
    public Slider slider;
}

public class TileManager : Singleton<TileManager> {
    private Dictionary<GameObject, TileData> tiles = new Dictionary<GameObject, TileData>();
    private Dictionary<GameObject, GameObject> tileUIs = new Dictionary<GameObject, GameObject>();
    private Dictionary<GameObject, TileUIComponent> tileUIComponents = new Dictionary<GameObject, TileUIComponent>();
    
    public void TileDamage(GameObject tile, float damage) {
        GameObject tileUI = null;

        if (!tileUIs.TryGetValue(tile, out tileUI)) {
            tileUI = ObjectManager.Instance.UseObject("TILE_UI");
            tileUI.transform.position = new Vector2(tile.transform.position.x - 4, tile.transform.position.y + 5);
            Transform tileUICanvas = tileUI.transform.Find("Canvas");

            TileUIComponent tileUIComponentTemp;
            tileUIComponentTemp.slider = tileUICanvas.transform.Find("Slider").GetComponent<Slider>();

            tileUIs.Add(tile, tileUI);
            tileUIComponents.Add(tileUI, tileUIComponentTemp);
        }

        tiles.TryGetValue(tile, out TileData tileData);
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

    public Dictionary<GameObject, TileData> TileDictionary { get { return tiles; } set { tiles = value; } }
}
