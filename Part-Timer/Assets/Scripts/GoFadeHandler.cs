using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoFadeHandler : MonoBehaviour {
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] float fadeSpeed = 1f;
    [SerializeField] SuperiorInfoSO superiorInfoSO;
    private int fade = 0;

    void FixedUpdate() {
        if (superiorInfoSO.health <= 0) {
            GameObject goCanvasObj = canvasGroup.transform.parent.gameObject;
            goCanvasObj.GetComponent<Canvas>().enabled = true;
            fade = 1;
        }

        if (fade == 1 && canvasGroup.alpha == 1) {
            StopCoroutine(FadeOutCoroutine());
            StartCoroutine(FadeInCoroutine());
        }

        if (fade == 1 && canvasGroup.alpha == 0) {
            StopCoroutine(FadeInCoroutine());
            StartCoroutine(FadeOutCoroutine());
        }

        // if (fade == 1) {
        //     if (canvasGroup.alpha >= 1) {
        //         canvasGroup.alpha = 0;
        //     } else {
        //         canvasGroup.alpha = 1;
        //     }
        // }
    }

    IEnumerator FadeInCoroutine() {
        yield return new WaitForSeconds(0.5f);
        while (canvasGroup.alpha > 0) {
            canvasGroup.alpha -= Time.deltaTime / fadeSpeed;
            yield return null;
        }
    }

    IEnumerator FadeOutCoroutine() {
        yield return new WaitForSeconds(0.5f);
        while (canvasGroup.alpha < 1) {
            canvasGroup.alpha += Time.deltaTime / fadeSpeed;
            yield return null;
        }
    }
}
