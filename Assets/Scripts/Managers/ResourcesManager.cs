using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : Singleton<ResourcesManager> {
    public T Load<T>(string path) where T : Object { return Resources.Load<T>(path); }

    public GameObject Instantiate(GameObject prefab, Transform parent = null) {
        GameObject clone = Object.Instantiate(prefab, parent);
        clone.name = clone.name.Replace("(Clone)", "");

        return clone;
    }

    public GameObject InstantiateWithPath(string path, Transform parent = null) {
        GameObject prefab = Load<GameObject>(path);

        if (prefab == null) {
            Debug.Log("���� ��ο��� ������ �ҷ����� ���� : " + path);
            return null;
        }

        GameObject clone = Object.Instantiate(prefab, parent);
        clone.name = clone.name.Replace("(Clone)", "");

        return clone;
    }
}