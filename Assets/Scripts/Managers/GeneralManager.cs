using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralManager : Singleton<GeneralManager> {
    [SerializeField] bool pause = false;
    [SerializeField] float originalFixedTime;
    [SerializeField] Vector3 mousePosition;
    [SerializeField] WaitForFixedUpdate wffu = new WaitForFixedUpdate();

    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start() {
        originalFixedTime = Time.fixedDeltaTime;
    }

    private void Update() {
        mousePosition = MousePositionUpdate();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode) {
        if (scene.buildIndex == 0) {
            pause = false;
            LetterBoxManager.Instance.LetterBox(false);
            ObjectManager.Instance.AllReturn();
        }
    }

    private Vector3 MousePositionUpdate() {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = Camera.main.nearClipPlane;

        return Camera.main.ScreenToWorldPoint(mouseScreenPosition);
    }

    public void TimeScale(float scale = 1.0f) {
        Time.timeScale = scale;
        Time.fixedDeltaTime = originalFixedTime * Time.timeScale;
    }

    public bool Pause { get { return pause; } set { pause = value; } }

    public Vector3 MousePosition { get { return new Vector3(mousePosition.x, mousePosition.y, 0); } }

    public WaitForFixedUpdate WFFU { get { return wffu; } }
}