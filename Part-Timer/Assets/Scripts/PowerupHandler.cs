using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupHandler : MonoBehaviour {
    public Text powerupText;
    public GameInfoSO gameInfoSO;

    void Update() {
        powerupText.text = gameInfoSO.playerPP.ToString();
    }
}
