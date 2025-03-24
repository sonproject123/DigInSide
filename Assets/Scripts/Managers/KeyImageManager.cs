using System.Collections.Generic;
using UnityEngine;

public enum KeyImage {
    E
}

public class KeyImageManager : Singleton<KeyImageManager> {
    Dictionary<KeyImage, GameObject> keyImageDict = new Dictionary<KeyImage, GameObject>();

    [SerializeField] GameObject imageE;

    private void Start() {
        keyImageDict.Add(KeyImage.E, Initiate(imageE));
        
    }

    private GameObject Initiate(GameObject original) {
        GameObject clone = ResourcesManager.Instance.Instantiate(original, this.transform);
        clone.SetActive(false);
        return clone;
    }

    public Dictionary<KeyImage, GameObject> KeyImageDict { get { return keyImageDict; } }
}
