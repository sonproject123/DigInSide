using UnityEngine;

public class NormalAttack1 : Attack {
    protected new void Awake() {
        base.Awake();
        ObjectName();
    }

    protected override void ObjectName() {
        objectName = "NORMAL_ATTACK1";
    }
}
