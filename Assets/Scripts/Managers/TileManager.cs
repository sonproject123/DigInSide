using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct TileData {
    public float hp;
    public int price;

    public TileData(float hp, int price) {
        this.hp = hp;
        this.price = price;
    }
}

public class TileManager : Singleton<TileManager> {
    private Dictionary<GameObject, TileData> tileDictionary = new Dictionary<GameObject, TileData>();

    public Dictionary<GameObject, TileData> TileDictionary { get { return tileDictionary; } set { tileDictionary = value; } }
}
