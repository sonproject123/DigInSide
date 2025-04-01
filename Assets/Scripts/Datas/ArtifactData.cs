using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ArtifactData {
    public int id;
    public string name;
    public string description;
    public string flavorText;
    public int tier;
}

[System.Serializable]
public class ArtifactDataList {
    public List<ArtifactData> artifactsData = new List<ArtifactData>();
}
