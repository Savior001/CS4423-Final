using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour {
    Text score;
    float point = 0;
    public static ScoreHandler singleton;

    void Awake() {
        if(singleton == null) {
            singleton = this;
        } else {
            Destroy(this.gameObject);
        }
    }

    void Start() {
        score = GetComponent<Text>();
        point = int.Parse(score.text);
    }

    public void AddScore(float p) {
        point += p;
        score.text = point.ToString();
    }

    public void DeductScore(float p) {
        if (point - p < 0) {
            point = 0;
        } else {
            point -= p;
            score.text = point.ToString();
        }
    }
}