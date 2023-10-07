using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupHandler : MonoBehaviour {
    Text powerupText;
    public float powerupCount = 0f;
    public float playerSpeed = 0f;
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
        powerupCount = int.Parse(powerupText.text);
    }

    public void AddPowerup() {
        playerSpeed += 0.25f;
        powerupCount += 1;
        powerupText.text = powerupCount.ToString();
    }
}
