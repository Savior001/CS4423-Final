using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSpawner : MonoBehaviour {
    [SerializeField] GameObject documentPrefab;
    [SerializeField] GameObject damagePrefab;
    [SerializeField] GameObject powerupPrefab;
    [SerializeField] SuperiorMovement superiorObject;
    [SerializeField] float spawnHeigth = 3f;
    GameObject spawnChoice;
    float spawnRate = 0f;
    public int phase = 1;
    private bool trasitionTime = true;
    
    void Start() {
        SpawnEntitiesOverTime();
    }

    void Update() {
        phase = superiorObject.phase;
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

                
                // if (entityPrefab.tag == "Damage") {
                //     if(number <= 1) {
                //         transform.rotation = Quaternion.Euler(0, 0, 0);
                //     } else if (number <= 2) {
                //         transform.rotation = Quaternion.Euler(0, 0, 120);
                //     } else {
                //         transform.rotation = Quaternion.Euler(0, 0, -90);
                //     }
                // }
                // spawnObject = Instantiate(spawnChoice, new Vector3(superiorObject.transform.position.x, spawnHeigth, 0), Quaternion.identity);
                if (phase == 1) {
                    int number = Random.Range(0, 3);
                    Quaternion rotation = Quaternion.Euler(0,0,0);
                    
                    if(number <= 1) {
                        rotation = Quaternion.Euler(0, 0, 0);
                    } else if (number <= 2) {
                        rotation = Quaternion.Euler(0, 0, 120);
                    } else {
                        rotation = Quaternion.Euler(0, 0, -90);
                    }

                    spawnObject = Instantiate(spawnChoice, new Vector3(superiorObject.transform.position.x, spawnHeigth, 0), rotation);
                } else {
                    if (trasitionTime) {
                        yield return new WaitForSeconds(6);
                        trasitionTime = false;
                    }

                    float rand = Random.Range(0f, 1f);
                    
                    if (rand < 0.5f)
                        spawnHeigth = 2f;
                    else
                        spawnHeigth = 4f;

                    spawnObject = Instantiate(damagePrefab, new Vector3(superiorObject.transform.position.x, superiorObject.transform.position.y - spawnHeigth, 0), Quaternion.identity);
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
