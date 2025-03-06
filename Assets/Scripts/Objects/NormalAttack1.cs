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

                tempTD.hp -= 5;
                TileManager.Instance.TileDictionary[tile] = tempTD;
                if (TileManager.Instance.TileDictionary[tile].hp <= 0)
                    Destroy(tile);
            }
        }

        ObjectManager.Instance.ReturnObject(gameObject, objectName);
    }
}
