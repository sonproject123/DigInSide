using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseManager : Singleton<MouseManager> {
    [SerializeField] Texture2D cursorNormal;
    [SerializeField] Vector2 center;

    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void State(int state) {
        if (state == 0)
            CursorChange(cursorNormal);
        else
            CursorChange(cursorNormal);
    }

    private void CursorChange(Texture2D cursor) {
        center = new Vector2(cursor.width / 2, cursor.height / 2);
        Cursor.SetCursor(cursor, center, CursorMode.ForceSoftware);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode) {
        State(scene.buildIndex);
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}