using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class DigRange : MonoBehaviour {
    private void OnMouseEnter() {
        PlayerStats.Instance.IsDiggable = true;
        MouseManager.Instance.CursorNameChange(Cursors.DIG);
    }

    private void OnMouseExit() {
        PlayerStats.Instance.IsDiggable = false;
        MouseManager.Instance.CursorNameChange(Cursors.NORMAL);
    }
}
