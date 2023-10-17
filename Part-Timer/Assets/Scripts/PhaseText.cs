using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseText : MonoBehaviour {
    [SerializeField] TimerText timerText;
    [SerializeField] SuperiorMovement superiorObject;
    // int timer = 0;
    // int phaseTwo = 10;
    public int phase = 1;
    public Text phaseText;
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
        // StartCoroutine(PhaseRoutine());
    }

    void FixedUpdate() {
        phaseText.text = superiorObject.phase.ToString();
        // timer = timerText.seconds;
    }

    // IEnumerator PhaseRoutine() {
    //     while(true){
    //         yield return new WaitForSeconds(1);
    //         if (timer == phaseTwo) {
    //             phase += 1;
    //             phaseText.text = phase.ToString();
    //             yield return null;
    //         }
    //         yield return null;
    //     }
    // }
}
