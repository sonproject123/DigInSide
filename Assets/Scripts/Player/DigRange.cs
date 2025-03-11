using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class DigRange : MonoBehaviour {
    private void OnMouseEnter() {
        Debug.Log("enter");
        PlayerStats.Instance.IsDiggable = true;
        MouseManager.Instance.CursorNameChange(Cursors.DIG);
    }

    private void OnMouseExit() {
        Debug.Log("exit");
        PlayerStats.Instance.IsDiggable = false;
        MouseManager.Instance.CursorNameChange(Cursors.NORMAL);
    }
}
