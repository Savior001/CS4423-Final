using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperiorMovement : MonoBehaviour {
    [System.Serializable]
    public class Superior {
        public Superior(float hp, float spd, float spdMultiplier, float timerCap) {
            health = hp;
            speed = spd;
            moveSpeedMultiplier = spdMultiplier;
            timerStop = timerCap;
        }

        [SerializeField] public float health;
        [SerializeField] public float speed;
        [SerializeField] public float moveSpeedMultiplier;
        [SerializeField] public float timerStop;
    }
    [SerializeField] float xPos;
    [SerializeField] float timer = 0f;
    [SerializeField] float transitionTime = 0.6f;
    [SerializeField] float lvlOneHealthFrom = 100f;
    [SerializeField] float lvlOneHealthTo = 200f;
    [SerializeField] float lvlOneTimerFrom = 50f;
    [SerializeField] float lvlOneTimerTo = 60f;
    [SerializeField] float lvlTwoHealthFrom = 300f;
    [SerializeField] float lvlTwoHealthTo = 400f;
    [SerializeField] float lvlTwoTimerFrom = 65f;
    [SerializeField] float lvlTwoTimerTo = 70f;
    [SerializeField] float lvlThreeHealthFrom = 500f;
    [SerializeField] float lvlThreeHealthTo = 700f;
    [SerializeField] float lvlThreeTimerFrom = 75f;
    [SerializeField] float lvlThreeTimerTo = 80f;
    Vector3 newPos;
    float runningTime = 0f;
    bool updatePhase = true;
    public int phase = 1;
    public GameInfoSO gameInfoSO;
    public SuperiorInfoSO superiorInfoSO;
    public Superior superior;

    void Start() {
        superior = SuperiorRandomizer();
        superiorInfoSO.LoadSuperiorStats(superior.health, superior.speed, superior.moveSpeedMultiplier, superior.timerStop);
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

    IEnumerator PhaseTransition() {
        yield return new WaitForSeconds(5);
        MoveToPhaseTwo();
    }

    void FixedUpdate() {
        runningTime = (runningTime + Time.deltaTime) * superior.moveSpeedMultiplier;
        if (timer > superior.timerStop) {
            phase = 2;
        }

        if (phase == 1) {
            Movement();
        } else {
            if (updatePhase) {
                StartCoroutine(PhaseTransition());
            } else {
                MovementPhaseTwo();
            }
        }
    }

    void Movement() {
        superior.moveSpeedMultiplier += timer;

        if (runningTime >= timer) {
            transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * superior.speed);

            if (Vector3.Distance(transform.position, newPos) <= 0.01f) {
                xPos = Random.Range(-4.5f, 4.5f);
                newPos = new Vector3(xPos, transform.position.y, transform.position.z);
                runningTime = 0.0f;
            }
        }
    }

    void MoveToPhaseTwo() {
        updatePhase = false;
        gameInfoSO.phase = phase;
        xPos = 7.5f;
        newPos = new Vector3(xPos, 0f, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * transitionTime);
        if (Vector3.Distance(transform.position, newPos) <= 0.01f) {
            xPos = Random.Range(-5.5f, 5.5f);
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
                Debug.Log("Current boss x pos: " + transform.position.x);
                xPos = Random.Range(6.5f, 8.5f);
                newPos = new Vector3(xPos, transform.position.y, transform.position.z);
                runningTime = 0f;
            }
        }
    }

    public void DealDamage(float damage) {
        superior.health -= damage;
        superiorInfoSO.DealDamage(damage);
    }

    public Superior SuperiorRandomizer() {
        if (gameInfoSO.level == 1) {
            return new Superior(Random.Range(lvlOneHealthFrom, lvlOneHealthTo),
                                Random.Range(1.5f, 2f),
                                Random.Range(.5f, 1f),
                                Random.Range(lvlOneTimerFrom, lvlOneTimerTo));
        } else if (gameInfoSO.level == 2) {
            return new Superior(Random.Range(lvlTwoHealthFrom, lvlTwoHealthTo),
                                Random.Range(2.5f, 3f),
                                Random.Range(1.5f, 2f),
                                Random.Range(lvlTwoTimerFrom, lvlTwoTimerTo));
        } else {
            return new Superior(Random.Range(lvlThreeHealthFrom, lvlThreeHealthTo),
                                Random.Range(3.5f, 6f),
                                Random.Range(2.5f, 3f),
                                Random.Range(lvlThreeTimerFrom, lvlThreeTimerTo));
        }
    }
}