using UnityEngine;

public class NormalAttack1 : Attack {
    protected new void Awake() {
        base.Awake();
        ObjectName();
    }

    protected override void ObjectName() {
        objectName = "NORMAL_ATTACK1";
    }

    protected override void AttackProcess() {
        for (int i = 0; i < tiles.Count; i++) {
            foreach (var tile in tiles[i]) {
                TileData tempTD;
                TileManager.Instance.TileDictionary.TryGetValue(tile, out tempTD);

                tempTD.hp -= 10;
                TileManager.Instance.TileDictionary[tile] = tempTD;
                Debug.Log(TileManager.Instance.TileDictionary[tile].hp);
            }
        }

        ObjectManager.Instance.ReturnObject(gameObject, objectName);
    }
}
