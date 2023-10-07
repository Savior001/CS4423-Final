using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour {
    Text score;
    int point = 0;
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

    public void AddScore() {
        point += 500;
        score.text = point.ToString();
    }

    public void DeductScore() {
        if (point - 100 < 0) {
            point = 0;
        } else {
            point -= 100;
            score.text = point.ToString();
        }
    }
}