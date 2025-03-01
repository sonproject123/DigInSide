using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {
    [SerializeField] Transform player;
    [SerializeField] Quaternion fixRotation;

    private void Awake() {
        fixRotation = transform.rotation;
    }

    private void LateUpdate() {
        transform.rotation = fixRotation;
    }
}