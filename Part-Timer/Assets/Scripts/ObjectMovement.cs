using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectMovement : MonoBehaviour {
    [SerializeField] GameObject entityPrefab;
    SuperiorMovement superiorObject;
    [SerializeField] float speed = 2f;
    private int number = 0;
    int phase = 1;

    void Awake() {
        superiorObject = GameObject.FindWithTag("Superior").gameObject.GetComponent<SuperiorMovement>();
    }

    void Start() {
        StartCoroutine(MoveCoroutine());
        //set velocity once
    }

    void FixedUpdate() {
        phase = superiorObject.phase;
        Debug.Log("Phase is: " + phase);
    }

    IEnumerator MoveCoroutine() {
        while (true) {
            // if (phase != 1) {
            //     yield return new WaitForSeconds(3);
            // }

            Vector3 vel = Vector3.zero;
            number = Random.Range(0, 1);

            if (phase == 1) {
                vel.y = -1;
            } else {
                vel.x = -1;
            }

            transform.position += vel * (speed + Random.Range(1.5f, 3)) * Time.deltaTime;

            if (entityPrefab.tag == "Damage") {
                if(number == 0) {
                    transform.Rotate(Vector3.forward);
                } else {
                    transform.Rotate(Vector3.back);
                }
            }
            yield return null;
        }
    }
}
