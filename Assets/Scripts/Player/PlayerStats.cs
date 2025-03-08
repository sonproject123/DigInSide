using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : Singleton<PlayerStats> {
    [SerializeField] Transform player;
    [SerializeField] Transform playerCenter;

    [SerializeField] float attack;
    [SerializeField] float speed;
    [SerializeField] float mass;

    [SerializeField] bool isMove;
    [SerializeField] bool isLeft;

    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode) {
        if (scene.buildIndex == 0) {
            GeneralManager.Instance.Pause = false;
            LetterBoxManager.Instance.LetterBox(false);
            ObjectManager.Instance.AllReturn();
            Initialize();
        }
        else {
            player = GameObject.Find("Player").transform;
            playerCenter = player.Find("Player Center");
        }
            player = GameObject.Find("Player").transform;
            playerCenter = player.Find("Player Center");
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void InitializedStats() {
        attack = 1;
        speed = 60;
        mass = 5;
    }

    private void Initialize() {
        InitializedStats();
    }

    #region Property
    public Transform Player{ get { return player; } }
    public Transform PlayerCenter{ get { return playerCenter; } }
    public float Attack { get { return attack; } set { attack = value; } }
    public float Speed { get { return speed; } set { speed = value; } }
    public float Mass{ get { return mass; } set { mass = value; } }
    public bool IsMove { get { return isMove; } set { isMove = value; } }
    public bool IsLeft{ get { return isLeft; } set { isLeft = value; } }
    #endregion
}