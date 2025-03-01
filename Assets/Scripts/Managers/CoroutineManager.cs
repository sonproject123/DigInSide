using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineManager {
    private static Dictionary<float, WaitForSeconds> dictionary = new Dictionary<float, WaitForSeconds>(new Compare());

    private class Compare : IEqualityComparer<float> {
        public bool Equals(float x, float y) {return x == y; }

        public int GetHashCode(float hash) {return hash.GetHashCode(); }
    }

    public static WaitForSeconds WaitForSecond(float time) {
        WaitForSeconds wfs;

        if (!dictionary.TryGetValue(time, out wfs)) {
            wfs = new WaitForSeconds(time);
            dictionary.Add(time, wfs);
        }

        return wfs;
    }
}