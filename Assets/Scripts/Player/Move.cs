using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class Move : MonoBehaviour {
    [SerializeField] Dictionary<KeyCode, Action> keyActions_GetKey = new Dictionary<KeyCode, Action>();
    [SerializeField] Dictionary<KeyCode, Action> keyActions_GetKeyDown = new Dictionary<KeyCode, Action>();
    [SerializeField] Dictionary<KeyCode, Action> keyActions_GetKeyUp = new Dictionary<KeyCode, Action>();

    private Rigidbody2D rb;

    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();

        DictionaryKey();
    }

    private void DictionaryKey() {
        keyActions_GetKey.Add(KeyCode.A, Left);
        keyActions_GetKey.Add(KeyCode.D, Right);
        keyActions_GetKey.Add(KeyCode.W, Up);
        keyActions_GetKey.Add(KeyCode.S, Down);
    }

    private void Update() {
        if (!Input.anyKey && !Input.GetMouseButton(0)) {
            PlayerStats.Instance.IsMove = false;
            return;
        }

        verticalInput = 0;
        horizontalInput = 0;

        OnMove(keyActions_GetKeyDown, Input.GetKeyDown);
        OnMove(keyActions_GetKey, Input.GetKey);
        OnMove(keyActions_GetKeyUp, Input.GetKeyUp);

        if (Input.GetMouseButtonDown(0))
            DigOne();
    }

    private void OnMove(Dictionary<KeyCode, Action> keyActions, Func<KeyCode, bool> inputMethod) {
        foreach (var keyAction in keyActions) {
            if (inputMethod(keyAction.Key))
                keyAction.Value.Invoke();
        }
    }

    private bool RaycastCheck(Vector3 dir) {
        bool center = Physics.Raycast(PlayerStats.Instance.PlayerCenter.position, dir, 0.3f, LayerMask.GetMask("Wall"));

        return !center;
    }

    private void Left() {
        horizontalInput = -1;
        RigidMove();
    }

    private void Right() {
        horizontalInput = 1;
        RigidMove();
    }

    private void Up() {
        verticalInput = 1;
        RigidMove();
    }

    private void Down() {
        verticalInput = -1;
        RigidMove();
    }

    private void RigidMove() {
        Vector2 dir = new Vector2(horizontalInput, verticalInput);
        if (RaycastCheck(dir))
            rb.MovePosition(rb.position + dir * PlayerStats.Instance.Speed * Time.deltaTime);
    }

    private void DigOne() {
        GameObject attack = ObjectManager.Instance.UseObject("NORMAL_ATTACK1");
        attack.transform.position = GeneralManager.Instance.MousePosition;
    }
}
