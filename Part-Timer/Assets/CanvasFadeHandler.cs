using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFadeHandler : MonoBehaviour {
    [SerializeField] CanvasGroup canvasGroup;
    public static CanvasFadeHandler singleton;

    void Awake() {
        if(singleton == null) {
            singleton = this;
        } else {
            Destroy(this.gameObject);
        }
        //Debug.Log("canvas alpha: " + canvasGroup.alpha);
    }

    public void FadeIn() {
        StartCoroutine(FadeInCoroutine());
    }
    
    IEnumerator FadeInCoroutine() {
        yield return new WaitForSeconds(1);
        while (canvasGroup.alpha < 1) {
            canvasGroup.alpha += Time.deltaTime / 2;
            //Debug.Log("canvas alpha updated to: " + canvasGroup.alpha);
            yield return null;
        }
    }
}
