using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperiorMovement : MonoBehaviour {
    [SerializeField] float speed = 2f;
    [SerializeField] float xPos;
    [SerializeField] float timer = 1f;
    [SerializeField] float moveSpeedMultiplier = 1f;
    [SerializeField] TimerText timerText;
    [SerializeField] PhaseText phaseText;
    Vector3 newPos;
    float runningTime = 0f;
    int phase = 1;
    bool updatePhase = true;

    void Start() {
        xPos = Random.Range(-4.5f, 4.5f);
        newPos = new Vector3(xPos, transform.position.y, transform.position.z);
    }

    void FixedUpdate() {
        phase = phaseText.phase;

        if (phase == 1) {
            Movement();
        } else {
            if (updatePhase) {
                MoveToPhaseTwo();
            }
            MovementPhaseTwo();
        }
    }

    void Movement() {
        timerText = TimerText.singleton;
        moveSpeedMultiplier += float.Parse(timerText.timerText.text) * 0.0001f;
        runningTime = (runningTime + Time.deltaTime) * moveSpeedMultiplier;

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
        runningTime = 0f;
        xPos = 7.5f;
        newPos = new Vector3(xPos, 0f, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * speed / 3);
        updatePhase = false;
    }

    void MovementPhaseTwo() {
        runningTime = (runningTime + Time.deltaTime);

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
