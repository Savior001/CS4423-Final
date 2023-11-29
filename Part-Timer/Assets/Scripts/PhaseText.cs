using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseText : MonoBehaviour {
    public int phase = 1;
    public Text phaseText;
    public GameInfoSO gameInfoSO;
    public static PhaseText singleton;

    void Awake() {
        if(singleton == null) {
            singleton = this;
        } else {
            Destroy(this.gameObject);
        }
    }

    void Start() {
        phaseText = GetComponent<Text>();
        phaseText.text = phase.ToString();
    }

    void Update() {
        phaseText.text = gameInfoSO.phase.ToString();
    }
}
