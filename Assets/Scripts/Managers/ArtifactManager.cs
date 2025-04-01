using System.Collections.Generic;
using Unity.Android.Gradle.Manifest;
using UnityEngine;

public struct ArtifactDataStruct {
    public int id;
    public ArtifactData data;

    public ArtifactDataStruct(int id, ArtifactData data) {
        this.id = id;
        this.data = data;
    }
}

public class ArtifactManager : Singleton<ArtifactManager> {
    Dictionary<GameObject, ArtifactDataStruct> artifacts = new Dictionary<GameObject, ArtifactDataStruct>();
    [SerializeField] List<Sprite> artifactSprites = new List<Sprite>();
    Dictionary<int, Sprite> artifactImagesDict = new Dictionary<int, Sprite>();

    private void Start() {
        for (int i = 1; i <= artifactSprites.Count; i++)
            artifactImagesDict.Add(i, artifactSprites[i - 1]);

        ArtifactInitiate();
    }

    private void ArtifactInitiate() {
        foreach (var artifact in JsonManager.Instance.ArtifactDict) {
            GameObject obj = ObjectManager.Instance.UseObject("ARTIFACT");
            SpriteRenderer objSprite = obj.GetComponent<SpriteRenderer>();

            objSprite.sprite = artifactImagesDict[artifact.Value.tier];
            ArtifactDataStruct data = new ArtifactDataStruct(artifact.Key, artifact.Value);
            artifacts.Add(obj, data);
            obj.SetActive(false);
        }
    }
}
