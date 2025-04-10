using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonManager : Singleton<JsonManager> {
    [SerializeField] Dictionary<string, ObjectData> objectDict = new Dictionary<string, ObjectData>();
    [SerializeField] Dictionary<int, ArtifactData> artifactDict = new Dictionary<int, ArtifactData>();

    private new void Awake() {
        base.Awake();
        LoadData();
    }

    private void LoadData() {
        TextAsset jsonData = Resources.Load<TextAsset>("JsonDatas/Object");
        ObjectDataList objectData = JsonUtility.FromJson<ObjectDataList>(jsonData.text);
        foreach (var data in objectData.objectsData)
            objectDict.Add(data.name, data);

        jsonData = Resources.Load<TextAsset>("JsonDatas/Artifact");
        ArtifactDataList artifactData = JsonUtility.FromJson<ArtifactDataList>(jsonData.text);
        foreach (var data in artifactData.artifactsData)
            artifactDict.Add(data.id, data);
    }

    public Dictionary<string, ObjectData> ObjectDict { get { return objectDict; } }
    public Dictionary<int, ArtifactData> ArtifactDict { get { return artifactDict; } }
}