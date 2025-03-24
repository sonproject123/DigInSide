using UnityEngine;

public class Gain : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Artifact")) {
            PlayerStats.Instance.NearThing = collision.gameObject;
            GameObject keyE = KeyImageManager.Instance.KeyImageDict[KeyImage.E];
            keyE.SetActive(true);
            keyE.transform.position = collision.transform.position + new Vector3(0, 0.75f, 0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Artifact")) {
            PlayerStats.Instance.NearThing = null;
            KeyImageManager.Instance.KeyImageDict[KeyImage.E].SetActive(false);
        }
    }
}
