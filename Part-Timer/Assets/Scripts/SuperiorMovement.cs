using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperiorMovement : MonoBehaviour {
    [SerializeField] float speed = 2.0f;
    [SerializeField] float xPos;
    [SerializeField] float timer = 1f;
    [SerializeField] float moveSpeedMultiplier = 1f;
    TimerText timerText;
    float runningTime = 0.0f;
    Vector3 newPos;

    void Start() {
        xPos = Random.Range(-4.5f, 4.5f);
        newPos = new Vector3(xPos, transform.position.y, transform.position.z);
    }

    void Update() {
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
}
