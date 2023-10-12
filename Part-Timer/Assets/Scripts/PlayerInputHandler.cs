using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInputHandler : MonoBehaviour {
    [SerializeField] Movement movement;
    [SerializeField] FallingPapersEffect fpe;
    public UnityEvent OnLandEvent;

    void Awake() {
        if (OnLandEvent == null) {
			OnLandEvent = new UnityEvent();
        }
    }

    void Update() {
        bool wasGrounded = movement.onGround;
        
        if (!wasGrounded) {
            OnLandEvent.Invoke();
        }

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
            //Debug.Log("Player is kill: " + e);
        }
    }
}
