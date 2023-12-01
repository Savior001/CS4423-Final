using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptHandler : MonoBehaviour {
    [SerializeField] float timer = 0f;
    [SerializeField] float fadeSpeed = 2;
    [SerializeField] Text text;
    [SerializeField] Text subtext;
    public GameInfoSO gameInfoSO;
    int stopCoroutine = 0;

    void Awake() {
        if (gameInfoSO.level > 1) {
            Destroy(this.gameObject);
        }
    }

    void Start() {
        text.text = "Catch them Papers!";
        text.color = new Color(0.3820755f, 0.4896945f, 1f, 1f);
        subtext.text = "(with a, w, d)";
        StartCoroutine(TimerRoutine());
            Debug.Log("Starting timer");
    }
    
    void FixedUpdate() {
        if (transform.GetComponent<CanvasGroup>().alpha == 0 && timer >= 5) {
            stopCoroutine = 1;
        }

        if (timer >= 5 && transform.GetComponent<CanvasGroup>().alpha == 1) {
            timer = 0f;
            StartCoroutine(FadeOutCoroutine());
            Debug.Log("Starting fade out");
        }

        if (stopCoroutine == 1) {
            timer = 0f;
            StopCoroutine(TimerRoutine());
            StopCoroutine(FadeOutCoroutine());
            Debug.Log("Stopping fade out and timer");
        }

        if (gameInfoSO.phase == 2 && stopCoroutine == 1) {
            text.text = "Stick it to the man!";
            text.color = new Color(0.9921569f, 0.2f, 2862745f, 1f);
            subtext.text = "(with RMB)";
            transform.GetComponent<CanvasGroup>().alpha = 1;
            stopCoroutine = 0;
            Debug.Log("Displaying second prompt");
        }
    }

    IEnumerator TimerRoutine() {
        while(true){
            yield return new WaitForSeconds(1);
            timer += 1;
            yield return null;
        }
    }

    IEnumerator FadeOutCoroutine() {
        yield return new WaitForSeconds(1);
        while (transform.GetComponent<CanvasGroup>().alpha > 0) {
            transform.GetComponent<CanvasGroup>().alpha -= Time.deltaTime / fadeSpeed;
            yield return null;
        }

        if (gameInfoSO.phase == 2) {
            Destroy(this.gameObject);
        }
    }
}
