using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperiorMovement : MonoBehaviour {
    [SerializeField] float speed = 2.0f;
    [SerializeField] float xPos;
    [SerializeField] float timer = 1f;
    [SerializeField] float moveSpeedMultiplier = 1f;
    [SerializeField] TimerText timerText;
    Vector3 newPos;
    float runningTime = 0.0f;
    bool phaseTwo = false;

    void Start() {
        xPos = Random.Range(-4.5f, 4.5f);
        newPos = new Vector3(xPos, transform.position.y, transform.position.z);
    }

    void Update() {
        if (timerText.timerText.text == "10") { phaseTwo = true; }

        if (!phaseTwo) {
            Movement();
        } else {
            MoveToPhaseTwo();
        }
    }

    void Movement() {
        timerText = TimerText.singleton;
        moveSpeedMultiplier += float.Parse(timerText.timerText.text) * 0.0001f;
        runningTime = (runningTime + Time.deltaTime) * moveSpeedMultiplier;

        if (runningTime >= timer) {
            if (timerText.timerText.text == "9") { return; }
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
        newPos = new Vector3(xPos, 0, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * speed / 3);
    }

    void MovementPhaseTwo() {
        runningTime = (runningTime + Time.deltaTime);

        if (runningTime >= timer) {
            transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * 2f);

            if (Vector3.Distance(transform.position, newPos) <= 0.01f) {
                xPos = Random.Range(-6.25f, 8.25f);
                newPos = new Vector3(xPos, transform.position.y, transform.position.z);
                runningTime = 0f;
            }
        }
    }
}
