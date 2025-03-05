using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour {
    [SerializeField] protected string objectName = "";
    [SerializeField] protected List<GameObject> circles = new List<GameObject>();
    [SerializeField] protected List<CircleCollider2D> circleColliders = new List<CircleCollider2D>();
    [SerializeField] protected Dictionary<int, List<GameObject>> tiles = new Dictionary<int, List<GameObject>>();

    protected abstract void ObjectName();
    protected abstract void AttackProcess();

    protected void Awake() {
        for (int i = 0; i < circles.Count; i++) {
            circleColliders.Add(circles[i].GetComponent<CircleCollider2D>());
            tiles.Add(i, new List<GameObject>());
        }
    }

    private void OnEnable() {
        tiles.Clear();
        StartCoroutine(TileAdd());
    }

    private IEnumerator TileAdd() {
        WaitForFixedUpdate wffu = GeneralManager.Instance.WFFU;
        yield return wffu;

        for (int i = 0; i < circleColliders.Count; i++) {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, circleColliders[i].radius);
            foreach (var hit in hitColliders) {
        Debug.Log(hit.name);
                if (hit.CompareTag("Tile")) {
                    tiles[i].Add(hit.gameObject);
                }
            }
        }

        AttackProcess();
    }
}
