using UnityEngine;

public class ItemStats : Singleton<ItemStats> {
    [SerializeField] float attack;
    [SerializeField] float attackMult;

    private void Start() {
        Initialize();
    }

    public void Initialize() {
        attack = 0;
        attackMult = 1;
    }

    public float Attack { get { return attack; } set { attack = value; } }
    public float AttackMult { get { return attackMult; } set { attackMult = value; } }
}