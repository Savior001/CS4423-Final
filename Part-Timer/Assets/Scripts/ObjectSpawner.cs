using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEntitySpawner : MonoBehaviour {
    [SerializeField] GameObject documentPrefab;
    [SerializeField] GameObject damagePrefab;
    [SerializeField] GameObject powerupPrefab;
    [SerializeField] GameObject superiorPrefab;
    [SerializeField] TimerText timerText;
    // [SerializeField] float despawnTimer = 3f;
    [SerializeField] float spawnHeigth = 3f;
    GameObject spawnChoice;
    float choice = 0f;
    bool runCoroutine = true;
    
    void Start() {
        SpawnEntitiesOverTime();
    }

    void FixedUpdate() {
        if (timerText.timerText.text == "10") {
            runCoroutine = false;
        }
    }

    void SpawnEntitiesOverTime() {
        StartCoroutine(SpawnEntitiesOverTimeRoutine());

        IEnumerator SpawnEntitiesOverTimeRoutine() {
            while(true) {
                if (!runCoroutine) {
                    yield return new WaitForSeconds(5f);
                    runCoroutine = true;
                }
                choice = Random.Range(0,250);
                // Debug.Log("Choice is: " + choice);
                
                if (choice % 25 == 0) {
                    spawnChoice = powerupPrefab;
                } else if (choice < 125) {
                    spawnChoice = documentPrefab;
                } else if (choice > 124) {
                    spawnChoice = damagePrefab;
                }

                yield return new WaitForSeconds(Random.Range(0.1f, 1.5f));
                GameObject spawnObject;
                spawnObject = Instantiate(spawnChoice, new Vector3(superiorPrefab.transform.position.x, spawnHeigth, 0), Quaternion.identity);
                // Destroy(spawnObject, despawnTimer);
                yield return null;
            }
            // yield return null;
        }
    }
}
