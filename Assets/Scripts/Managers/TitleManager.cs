using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour {

    public void SceneLoad(int num) {
        StartCoroutine(SceneryManager.Instance.AsyncLoad(num));
    }

    public void Continue() {
        Debug.Log("Continue");
    }

    public void GameExit() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}