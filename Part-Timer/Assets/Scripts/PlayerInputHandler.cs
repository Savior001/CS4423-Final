using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour {
    [SerializeField] Movement movement;
    [SerializeField] FallingPapersEffect fpe;
    private int debugCount = 0;

    void Update() {
        try {
            if (Input.GetKey(KeyCode.A)) {
                movement.Move(new Vector3(-1, 0, 0));
                fpe.ActivateEffect(new Vector3(-1, 0, 0));
            } else if (Input.GetKey(KeyCode.D)) {
                movement.Move(new Vector3(1, 0, 0));
                fpe.ActivateEffect(new Vector3(1, 0, 0));
            } else {
                movement.Stop();
                fpe.ActivateEffect(Vector3.zero);
            }

            if (Input.GetKeyDown(KeyCode.Space)) { movement.Jump(); }
        } catch (Exception e) {
            if (debugCount == 0) {
                Debug.Log("Error on Update() call, player is kill: " + e);
                debugCount += 1;
            }
        }
    }
}
