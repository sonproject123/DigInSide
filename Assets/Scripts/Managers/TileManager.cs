using System;
using System.Collections.Generic;
using UnityEngine;

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

public class TileManager : Singleton<TileManager> {
    private Dictionary<GameObject, TileData> tileDictionary = new Dictionary<GameObject, TileData>();
    
    public void TileHp(GameObject tile) {

    }

    public Dictionary<GameObject, TileData> TileDictionary { get { return tileDictionary; } set { tileDictionary = value; } }
}
