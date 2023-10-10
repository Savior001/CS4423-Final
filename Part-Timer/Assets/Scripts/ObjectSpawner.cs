using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSpawner : MonoBehaviour {
    [SerializeField] GameObject documentPrefab;
    [SerializeField] GameObject damagePrefab;
    [SerializeField] GameObject powerupPrefab;
    [SerializeField] GameObject superiorPrefab; //object only use prefab if its reference from project
    [SerializeField] PhaseText phaseText;
    [SerializeField] float spawnHeigth = 3f;
    GameObject spawnChoice;
    float spawnRate = 0f;
    int phase = 1;
    
    void Start() {
        SpawnEntitiesOverTime();
    }

    void FixedUpdate() {
        phase = phaseText.phase;
    }

    void SpawnEntitiesOverTime() {
        StartCoroutine(SpawnEntitiesOverTimeRoutine());

        IEnumerator SpawnEntitiesOverTimeRoutine() {
            while(true) {
                // if (phase != 1) {
                //     yield return new WaitForSeconds(3);
                // }

                spawnRate = Random.Range(0,250);
                spawnChoice = GetSpawnChoice(spawnRate);

                yield return new WaitForSeconds(Random.Range(0.1f, 1.5f));
                GameObject spawnObject;

                // spawnObject = Instantiate(spawnChoice, new Vector3(superiorPrefab.transform.position.x, spawnHeigth, 0), Quaternion.identity);
                if (phase == 1) {
                    spawnObject = Instantiate(spawnChoice, new Vector3(superiorPrefab.transform.position.x, spawnHeigth, 0), Quaternion.identity);
                } else {
                    float rand = Random.Range(0f, 1f);
                    
                    if (rand < 0.5f)
                        spawnHeigth -= 0.25f;
                    else
                        spawnHeigth -= 0.75f;

                    spawnObject = Instantiate(damagePrefab, superiorPrefab.transform.position, Quaternion.identity);
                }
                yield return null;
            }
            // yield return null;
        }
    }

    private GameObject GetSpawnChoice(float spawnRate) {
        GameObject prefab = null;

        if (spawnRate % 25 == 0) {
            prefab = powerupPrefab;
        } else if (spawnRate < 125) {
            prefab = documentPrefab;
        } else if (spawnRate > 124) {
            prefab = damagePrefab;
        } else {
            prefab = damagePrefab;
        }

        return prefab;
    }
}
