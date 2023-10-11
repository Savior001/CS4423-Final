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
    PowerupHandler powerupHandler;
    CanvasFadeHandler canvasFadeHandler;

    void Start() {
        scoreHandler = ScoreHandler.singleton;
        healthHandler = HealthHandler.singleton;
        powerupHandler = PowerupHandler.singleton;
        canvasFadeHandler = CanvasFadeHandler.singleton;
        // unitGetClip = Resources.Load<AudioClip>("UnitGet");
        // audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collisionEntity) {
        if (entityPrefab.tag == "Document") {
            // Debug.Log("[" + entityPrefab.tag + "] collision with " + collisionEntity.tag);
            if (collisionEntity.tag == "Player") {

                // code catching animations here i think

                scoreHandler.AddScore(150);
                Destroy(this.gameObject);
            } else if (collisionEntity.tag == "Despawn") {
                scoreHandler.DeductScore(5);
                Destroy(this.gameObject);
            }
        }

        if(entityPrefab.tag == "Damage") {
            // Debug.Log("[" + entityPrefab.tag + "] collision with " + collisionEntity.tag);
            if (collisionEntity.tag == "Player") {
                healthHandler.DealDamage(10);

                if (healthHandler.hp == 0) {
                    Debug.Log("You ded...");
                    canvasFadeHandler.FadeIn();
                    Destroy(collisionEntity.gameObject);
                }

                scoreHandler.DeductScore(50);
                Destroy(this.gameObject);
            } else if (collisionEntity.tag == "Despawn") {
                Destroy(this.gameObject);
            }
        }

        if (entityPrefab.tag == "Powerup") {
            // Debug.Log("[" + entityPrefab.tag + "] collision with " + collisionEntity.tag);
            if (collisionEntity.tag == "Player") {
                // add powerup count or signify type of powerup
                powerupHandler.AddPowerup();
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
