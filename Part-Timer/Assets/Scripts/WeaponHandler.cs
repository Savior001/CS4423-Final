using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour {
    GameObject playerObj;
    GameObject playerBody;
    private int debugCount = 0;

    void Awake() {
        try {
            playerObj = GameObject.FindWithTag("Player");
            playerBody = playerObj.transform.GetChild(0).gameObject;
            // animator = GetComponent<Animator>();
        } catch (Exception e) {
            if (debugCount == 0) {
                Debug.Log("Error on Awake(), player is kill: " + e);
                debugCount += 1;
            }
        }
    }

    void Update() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.rotation = Quaternion.LookRotation(transform.forward, mousePos - transform.position);

        if (playerBody.transform.localScale.x == 1) {
            if (transform.rotation.eulerAngles.z < 0 || transform.rotation.eulerAngles.z > 180) {
                transform.localScale = new Vector3(-1, 1, 0);
            } else {
                transform.localScale = new Vector3(1, 1, 0);
            }
        } else {
            if (transform.rotation.eulerAngles.z > 0 && transform.rotation.eulerAngles.z < 180) {
                transform.localScale = new Vector3(-1, 1, 0);
            } else {
                transform.localScale = new Vector3(1, 1, 0);
            }
        }
    }
}
