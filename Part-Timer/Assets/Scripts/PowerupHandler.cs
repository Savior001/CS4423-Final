using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupHandler : MonoBehaviour {
    Text powerupText;
    int count = 0;
    public static PowerupHandler singleton;

    void Awake() {
        if(singleton == null) {
            singleton = this;
        } else {
            Destroy(this.gameObject);
        }
    }

    void Start() {
        powerupText = GetComponent<Text>();
        count = int.Parse(powerupText.text);
    }

    public void AddPowerup() {
        count += 1;
        powerupText.text = count.ToString();
    }
}
