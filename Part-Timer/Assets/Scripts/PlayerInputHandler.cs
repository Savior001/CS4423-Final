using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour {
    [SerializeField] Movement movement;
    [SerializeField] LayerMask groundMask;
    [SerializeField] LayerMask wallWask;
    [SerializeField] float wallDistance = 1f;
    [SerializeField] float groundDistance = 1f;

    void Update() {
        
        if (Input.GetKey(KeyCode.A)) { movement.Move(new Vector3(-1, 0, 0)); }
        else if (Input.GetKey(KeyCode.D)) { movement.Move(new Vector3(1, 0, 0)); }
        else { movement.Stop(); }

        if (Input.GetKeyDown(KeyCode.Space)) { movement.Jump(); }
        if (Physics2D.OverlapCircleAll(transform.position - new Vector3(0, 0.5f, 0), wallDistance, wallWask).Length > 0 &&
            Physics2D.OverlapCircleAll(transform.position - new Vector3(0, 0.5f, 0), groundDistance, groundMask).Length < 0.05f) {
            movement.Stop();
        }
    }
}
