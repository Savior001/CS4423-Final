using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerText : MonoBehaviour {
    public int seconds = 0;
    public Text timerText;
    public static TimerText singleton;

    void Awake() {
        if(singleton == null) {
            singleton = this;
        } else {
            Destroy(this.gameObject);
        }
    }

    void Start() {
        timerText = GetComponent<Text>();
        StartCoroutine(TimerRoutine());
    }

    IEnumerator TimerRoutine() {
        while(true){
            yield return new WaitForSeconds(1);
            seconds += 1;
            timerText.text = seconds.ToString();
            yield return null;
        }
    }
}
