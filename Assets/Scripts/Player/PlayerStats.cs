using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : Singleton<PlayerStats> {
    private Dictionary<int, int> skillLevels = new Dictionary<int, int>();
    private Dictionary<int, string> attackObjectCodes = new Dictionary<int, string>();
    [SerializeField] Transform player;
    [SerializeField] Transform playerCenter;

    [SerializeField] float attack;
    [SerializeField] float speed;
    [SerializeField] float goldGain;
    [SerializeField] float cooldown;
    [SerializeField] string attackObject;
    [SerializeField] int durability;

    [SerializeField] bool isMove;
    [SerializeField] bool isLeft;
    [SerializeField] bool isDiggable;

    [SerializeField] bool Drill;

    [SerializeField] GameObject nearThing;

    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode) {
        if (scene.buildIndex == 0)
            Initialize();

        player = GameObject.Find("Player").transform;
        if (player != null)
            playerCenter = player.Find("Player Center");
    }

    public void InitializedStats() {
        attack = 1;
        speed = 15;
        goldGain = 1;
        cooldown = 2;
        attackObject = attackObjectCodes[0];
        durability = 100;

        isMove = false;
        isLeft = false;
        isDiggable = false;
    }

    private void Initialize() {
        AttackObjectAdd();
        SkillLevelInitialize();
        InitializedStats();
    }

    private void AttackObjectAdd() {
        attackObjectCodes.Add(0, "NORMAL_ATTACK1");
        attackObjectCodes.Add(1, "NORMAL_ATTACK2");
        attackObjectCodes.Add(2, "NORMAL_ATTACK3");
        attackObjectCodes.Add(3, "NORMAL_ATTACK4");
        attackObjectCodes.Add(4, "NORMAL_ATTACK5");
        attackObjectCodes.Add(5, "NORMAL_ATTACK6");
    }

    private void SkillLevelInitialize() {
        foreach(int id in JsonManager.Instance.ArtifactDict.Keys)
            skillLevels.Add(id, 0);
    }

    #region Property
    public Dictionary<int, int> SkillLevels { get { return skillLevels; } }
    public Dictionary<int, string> AttackObjectCodes { get { return attackObjectCodes; } }
    public Transform Player{ get { return player; } }
    public Transform PlayerCenter{ get { return playerCenter; } }
    public float Attack { get { return attack; } set { attack = value; } }
    public float Speed { get { return speed; } set { speed = value; } }
    public float GoldGain { get { return goldGain; } set { goldGain = value; } }
    public float Cooldown { get { return cooldown; } set { cooldown = value; } }
    public string AttackObject { get { return attackObject; } set { attackObject = value; } }
    public int Durability { get { return durability; } set { durability = value; } }
    public bool IsMove { get { return isMove; } set { isMove = value; } }
    public bool IsLeft{ get { return isLeft; } set { isLeft = value; } }
    public bool IsDiggable { get { return isDiggable; } set { isDiggable = value; } }
    public GameObject NearThing { get { return nearThing; } set { nearThing = value; } }
    #endregion
}