using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Cursors {
    NORMAL,
    DIG
}

public class MouseManager : Singleton<MouseManager> {
    Dictionary<Cursors, Texture2D> cursorDictionary = new Dictionary<Cursors, Texture2D>();
    
    [SerializeField] Texture2D cursorNormal;
    [SerializeField] Texture2D cursorDig;

    [SerializeField] Vector2 center;

    private new void Awake() {
        base.Awake();
        cursorDictionary.Add(Cursors.NORMAL, cursorNormal);
        cursorDictionary.Add(Cursors.DIG, cursorDig);
    }

    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void State(int state) {
        if (state == 0)
            CursorChange(cursorNormal);
        else
            CursorChange(cursorNormal);
    }

    public void CursorNameChange(Cursors cursor) {
        if (cursorDictionary.TryGetValue(cursor, out Texture2D texture))
            CursorChange(texture);
    }

    private void CursorChange(Texture2D cursor) {
        center = new Vector2(cursor.width / 2, cursor.height / 2);
        //center = new Vector2(cursor.width / 8, 0);
        Cursor.SetCursor(cursor, center, CursorMode.ForceSoftware);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode) {
        State(scene.buildIndex);
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}