using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour {
    [SerializeField] Movement movement;
    [SerializeField] FallingPapersEffect fpe;
    [SerializeField] ProjectileSpawner projectileSpawner;
    [SerializeField] GameObject superiorObject;
    [SerializeField] int phase = 1;
    GameObject playerObject;
    // private Movement movement;
    // private FallingPapersEffect fpe;
    // private ProjectileSpawner projectileSpawner;
    private int debugCount = 0;

    void Awake() {
        playerObject = GameObject.FindWithTag("Player").gameObject;
        // movement = playerObject.GetComponent<Movement>();
        // fpe = playerObject.transform.GetChild(0).GetComponent<FallingPapersEffect>();
    }

    void Update() {
        try {
            phase = superiorObject.GetComponent<SuperiorMovement>().phase;
        } catch (Exception e) {
            if (debugCount == 0) {
                Debug.Log("Error on Update() call, boss is kill: " + e);
                debugCount += 1;
            }
        }

        // if (phase == 2) {
        //     UpdatePlayerObject();
        // }

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

            if (Input.GetKeyDown(KeyCode.Space)) {
                movement.Jump();
            }

            if (phase == 2) {
                if (Input.GetMouseButtonDown(0)) {
                    projectileSpawner.ShootStaple(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                }
            }
        } catch (Exception e) {
            if (debugCount == 0) {
                Debug.Log("Error on Update() call, player is kill: " + e);
                debugCount += 1;
            }
        }
    }
    
    void UpdatePlayerObject() {
        GameObject newPlayerObject = GameObject.FindWithTag("PlayerShoot").gameObject;
        Debug.Log("Shooter active = " + newPlayerObject.activeSelf);
        newPlayerObject.SetActive(true);
        playerObject.SetActive(false);

        movement = newPlayerObject.GetComponent<Movement>();
        fpe = newPlayerObject.transform.GetChild(0).GetComponent<FallingPapersEffect>();
        projectileSpawner = newPlayerObject.transform.GetChild(0).transform.GetChild(0).GetComponent<ProjectileSpawner>();
    }
}
