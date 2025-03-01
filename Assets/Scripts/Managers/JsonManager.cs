using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonManager : Singleton<JsonManager> {
    [SerializeField] Dictionary<string, ObjectData> objectDict = new Dictionary<string, ObjectData>();

    private new void Awake() {
        base.Awake();
        LoadData();
    }

    private void LoadData() {
        TextAsset jsonData = Resources.Load<TextAsset>("JsonDatas/Object");
        ObjectDataList objectData = JsonUtility.FromJson<ObjectDataList>(jsonData.text);
        foreach (var data in objectData.objectsData)
            objectDict.Add(data.name, data);
    }

    public Dictionary<string, ObjectData> ObjectDict { get { return objectDict; } }
}