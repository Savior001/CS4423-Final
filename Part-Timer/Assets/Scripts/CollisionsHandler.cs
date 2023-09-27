using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionsHandler : MonoBehaviour {
    [SerializeField] GameObject entityPrefab;
    // [SerializeField] AudioClip unitGetClip;
    // AudioSource audioSource;
    ScoreHandler scoreHandler;
    HealthHandler healthHandler;

    void Start() {
        scoreHandler = ScoreHandler.singleton;
        healthHandler = HealthHandler.singleton;
        // unitGetClip = Resources.Load<AudioClip>("UnitGet");
        // audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collisionEntity) {
        if (entityPrefab.tag == "Document") {
            // Debug.Log("[" + entityPrefab.tag + "] collision with " + collisionEntity.tag);
            if (collisionEntity.tag == "Player") {
                scoreHandler.AddScore();
                Destroy(this.gameObject);
            } else if (collisionEntity.tag == "Despawn") {
                Destroy(this.gameObject);
            }
        }

        if(entityPrefab.tag == "Damage") {
            // Debug.Log("[" + entityPrefab.tag + "] collision with " + collisionEntity.tag);
            if (collisionEntity.tag == "Player") {
                healthHandler.DealDamage(10);

                if (healthHandler.hp == 0) {
                    Debug.Log("You ded...");
                    Destroy(collisionEntity.gameObject);
                }

                scoreHandler.DeductScore();
                Destroy(this.gameObject);
            } else if (collisionEntity.tag == "Despawn") {
                Destroy(this.gameObject);
            }
        }

    }

    // void OnTriggerExit2D(Collider2D collisionEntity) {
    //     if(entityPrefab.tag == "Edge") {
    //         Debug.Log("[" + entityPrefab.tag + "] collision with " + collisionEntity.tag);
    //     }
    // }
}
