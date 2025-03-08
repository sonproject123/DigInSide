using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour {
    [SerializeField] protected string objectName = "";
    [SerializeField] protected List<GameObject> circles = new List<GameObject>();
    [SerializeField] protected List<CircleCollider2D> circleColliders = new List<CircleCollider2D>();
    [SerializeField] protected Dictionary<int, List<GameObject>> tiles = new Dictionary<int, List<GameObject>>();

    protected abstract void ObjectName();

    protected void Awake() {
        for (int i = 0; i < circles.Count; i++) {
            circleColliders.Add(circles[i].GetComponent<CircleCollider2D>());
            tiles.Add(i, new List<GameObject>());
        }
    }

    private void OnEnable() {
        for (int i = 0; i < tiles.Count; i++)
            tiles[i].Clear();
        StartCoroutine(TileAdd());
    }

    private IEnumerator TileAdd() {
        WaitForFixedUpdate wffu = GeneralManager.Instance.WFFU;
        yield return wffu;

        for (int i = 0; i < circleColliders.Count; i++) {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, circleColliders[i].radius);
            foreach (var hit in hitColliders) {
                if (hit.CompareTag("Tile"))
                    tiles[i].Add(hit.gameObject);
            }
        }

        AttackProcess();
    }

    protected void AttackProcess() {
        for (int i = 0; i < tiles.Count; i++) {
            foreach (var tile in tiles[i]) {
                if (tile == null)
                    continue;

                TileManager.Instance.TileDamage(tile, 5);
            }
        }

        ObjectManager.Instance.ReturnObject(gameObject, objectName);
    }
}
