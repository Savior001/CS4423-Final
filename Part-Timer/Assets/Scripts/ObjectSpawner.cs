using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEntitySpawner : MonoBehaviour {
    [SerializeField] GameObject documentPrefab;
    [SerializeField] GameObject damagePrefab;
    [SerializeField] GameObject powerupPrefab;
    [SerializeField] GameObject superiorPrefab;
    // [SerializeField] float despawnTimer = 3f;
    [SerializeField] float spawnHeigth = 3f;
    GameObject spawnChoice;
    float choice = 0f;
    
    void Start() {
        SpawnEntitiesOverTime();
    }

    void SpawnEntitiesOverTime() {
        StartCoroutine(SpawnEntitiesOverTimeRoutine());

        IEnumerator SpawnEntitiesOverTimeRoutine() {
            while(true) {
                choice = Random.Range(1,100);
                // Debug.Log("Choice is: " + choice);
                
                if (choice == 50) {
                    spawnChoice = powerupPrefab;
                } else if (choice < 50) {
                    spawnChoice = documentPrefab;
                } else if (choice > 50) {
                    spawnChoice = damagePrefab;
                }

                yield return new WaitForSeconds(Random.Range(0.1f, 1.5f));
                GameObject spawnObject;
                spawnObject = Instantiate(spawnChoice, new Vector3(superiorPrefab.transform.position.x, spawnHeigth, 0), Quaternion.identity);
                // Destroy(spawnObject, despawnTimer);
                yield return null;
            }
        }
    }
}
