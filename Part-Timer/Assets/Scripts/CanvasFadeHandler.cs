using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasFadeHandler : MonoBehaviour {
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] Button retryButton;
    [SerializeField] Button quitButton;
    [SerializeField] float fadeSpeed = 2;
    public static CanvasFadeHandler singleton;

    void Awake() {
        if(singleton == null) {
            singleton = this;
        } else {
            Destroy(this.gameObject);
        }
        //Debug.Log("canvas alpha: " + canvasGroup.alpha);
    }

    void Start() {
        retryButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
    }

    public void FadeIn() {
        retryButton.gameObject.SetActive(true);
        retryButton.interactable = false;
        quitButton.gameObject.SetActive(true);
        quitButton.interactable = false;
        StartCoroutine(FadeInCoroutine());
    }

    public void Transition() {
        
    }
    
    IEnumerator FadeInCoroutine() {
        yield return new WaitForSeconds(1);
        while (canvasGroup.alpha < 1) {
            canvasGroup.alpha += Time.deltaTime / fadeSpeed;
            //Debug.Log("canvas alpha updated to: " + canvasGroup.alpha);
            yield return null;
        }
        retryButton.interactable = true;
        quitButton.interactable = true;
    }
}
