using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperiorMovement : MonoBehaviour {
    [SerializeField] float speed = 2f;
    [SerializeField] float xPos;
    [SerializeField] float timer = 0f;
    [SerializeField] float moveSpeedMultiplier = 1f;
    Vector3 newPos;
    float runningTime = 0f;
    bool updatePhase = true;
    public int phase = 1;

    void Start() {
        StartCoroutine(TimerRoutine());
        xPos = Random.Range(-4.5f, 4.5f);
        newPos = new Vector3(xPos, transform.position.y, transform.position.z);
    }

    IEnumerator TimerRoutine() {
        while(true){
            yield return new WaitForSeconds(1);
            timer += 1;
            yield return null;
        }
    }

    void FixedUpdate() {
        runningTime = (runningTime + Time.deltaTime) * moveSpeedMultiplier;
        if (timer > 10) { phase = 2; }

        if (phase == 1) {
            Movement();
        } else {
            if (updatePhase) {
                MoveToPhaseTwo();
            } else {
                MovementPhaseTwo();
            }
        }
    }

    void Movement() {
        moveSpeedMultiplier += timer;
        // runningTime = (runningTime + Time.deltaTime) * moveSpeedMultiplier;

        if (runningTime >= timer) {
            transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * speed);

            if (Vector3.Distance(transform.position, newPos) <= 0.01f) {
                xPos = Random.Range(-4.5f, 4.5f);
                newPos = new Vector3(xPos, transform.position.y, transform.position.z);
                runningTime = 0.0f;
            }
        }
    }

    void MoveToPhaseTwo() {
        updatePhase = false;
        xPos = 7.5f;
        newPos = new Vector3(xPos, 0f, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * speed / 3);
        if (Vector3.Distance(transform.position, newPos) <= 0.01f) {
            xPos = Random.Range(-4.5f, 4.5f);
            newPos = new Vector3(xPos, transform.position.y, transform.position.z);
            runningTime = 0.0f;
            // updatePhase = false;
        }
        // updatePhase = false;
    }

    void MovementPhaseTwo() {
        // runningTime = (runningTime + Time.deltaTime);

        if (runningTime >= timer) {
            transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * 2f);

            if (Vector3.Distance(transform.position, newPos) <= 0.01f) {
                xPos = Random.Range(6.5f, 8.5f);
                newPos = new Vector3(xPos, transform.position.y, transform.position.z);
                runningTime = 0f;
            }
        }
    }
}
