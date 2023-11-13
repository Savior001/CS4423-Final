using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour {
    public Text score;
    public GameInfoSO gameInfoSO;
    public static ScoreHandler singleton;

    void Update() {
        score.text = gameInfoSO.playerScore.ToString();
    }
}