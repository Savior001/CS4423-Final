using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHandler : MonoBehaviour {
    public Text healthbar;
    public GameInfoSO gameInfoSO;
    public static HealthHandler singleton;

    // void Awake() {
    //     if(singleton == null) {
    //         singleton = this;
    //     } else {
    //         Destroy(this.gameObject);
    //     }
    // }

    void Update() {
        healthbar.text = gameInfoSO.playerHP.ToString();
    }
}
