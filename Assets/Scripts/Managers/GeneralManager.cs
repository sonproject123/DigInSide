using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GeneralManager : Singleton<GeneralManager> {
    [SerializeField] bool pause = false;
    [SerializeField] float originalFixedTime;
    [SerializeField] Vector3 mousePosition;
    [SerializeField] WaitForFixedUpdate wffu = new WaitForFixedUpdate();

    private void Start() {
        originalFixedTime = Time.fixedDeltaTime;
    }

    private void Update() {
        MouseLocation = MousePosition();
    }

    public Vector3 MousePosition() {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = Camera.main.nearClipPlane;

        return Camera.main.ScreenToWorldPoint(mouseScreenPosition);
    }

    public void TimeScale(float scale = 1.0f) {
        Time.timeScale = scale;
        Time.fixedDeltaTime = originalFixedTime * Time.timeScale;
    }

    public bool Pause { get { return pause; } set { pause = value; } }

    public Vector3 MouseLocation { get { return mousePosition; } set { mousePosition = value; } }

    public WaitForFixedUpdate WFFU { get { return wffu; } }
}