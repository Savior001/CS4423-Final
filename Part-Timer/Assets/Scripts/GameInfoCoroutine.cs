using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfoCoroutine : MonoBehaviour {
    public GameInfoSO gameInfoSO;
    
    void Start() {
        gameInfoSO.StartTimer(this);
    }
}
