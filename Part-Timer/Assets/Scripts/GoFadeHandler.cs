using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoFadeHandler : MonoBehaviour {
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] float fadeSpeed = 2;
    [SerializeField] SuperiorInfoSO superiorInfoSO;
    private int fade = 0;

    void FixedUpdate() {
        if (superiorInfoSO.health <= 0) {
            GameObject goCanvasObj = canvasGroup.transform.parent.gameObject;
            goCanvasObj.GetComponent<Canvas>().enabled = true;
            StartCoroutine(FadeInCoroutine());
        }
    }
    
    IEnumerator FadeInCoroutine() {
        yield return new WaitForSeconds(0.5f);
        while (true) {
            if (canvasGroup.alpha < 1 && fade == 0) {
                canvasGroup.alpha += Time.deltaTime / fadeSpeed;

                if (canvasGroup.alpha == 1) {
                    fade = 1;
                }
            } else {
                canvasGroup.alpha -= Time.deltaTime / fadeSpeed;

                if (canvasGroup.alpha == 0) {
                    fade = 0;
                }
            }
            //Debug.Log("canvas alpha updated to: " + canvasGroup.alpha);
            yield return null;
        }
    }
}
