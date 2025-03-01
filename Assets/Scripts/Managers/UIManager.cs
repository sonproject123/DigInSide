using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject pauseBackground;

    [SerializeField] Slider hpBar;
    [SerializeField] Text hpText;
    [SerializeField] Text hpMaxText;

    [SerializeField] bool isUILocked;

    public static Action<float, bool> OnUIAlpha;
    public static Action OnUpdateHpBar;

    private void Awake() {
        canvas = gameObject.GetComponent<Canvas>();
        pauseBackground.SetActive(false);

        OnUIAlpha = (float alpha, bool uiLock) => { ForcedUIAlpha(alpha, uiLock); };

        //OnUpdateHpBar = () => { HpBar(); };
    }

    private void Start() {
        isUILocked = false;

        //hpBar.maxValue = Stats.Instance.MaxHp;
        //hpMaxText.text = Stats.Instance.MaxHp.ToString();
        //HpBar();
    }

    public void MouseOn() {
        if (!isUILocked)
            StartCoroutine(UIAlpha(0.01f));
    }

    public void MouseOff() {
        if (!isUILocked)
            StartCoroutine(UIAlpha(1));
    }

    private void ForcedUIAlpha(float alpha, bool uiLock) {
        isUILocked = uiLock;
        StartCoroutine(UIAlpha(alpha));
    }

    IEnumerator UIAlpha(float alpha) {
        WaitForFixedUpdate wffu = GeneralManager.Instance.WFFU;
        float time = 0;
        float currentAlpha = canvas.GetComponent<CanvasGroup>().alpha;
        float duration = 0.2f;

        while (time < duration) {
            time += Time.deltaTime;

            float t = Mathf.Clamp01(time / duration);
            canvas.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(currentAlpha, alpha, t);

            yield return wffu;
        }
    }

    //private void HpBar() {
    //    hpBar.value = Stats.Instance.Hp;
    //    if (Stats.Instance.Hp <= 0.0)
    //        hpText.text = "0";
    //    else
    //        hpText.text = Stats.Instance.Hp.ToString();
    //}
}