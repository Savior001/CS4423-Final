using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionsHandler : MonoBehaviour {
    [SerializeField] GameObject entityPrefab;
    GameObject playerObject;
    GameObject playerBody;
    
    ProjectileSpawner projectileSpawner;
    // [SerializeField] AudioClip unitGetClip;
    // AudioSource audioSource;
    ScoreHandler scoreHandler;
    HealthHandler healthHandler;
    PowerupHandler powerupHandler;
    CanvasFadeHandler canvasFadeHandler;
    Animator animator;
    private int debugCount = 0;
    float damage = 0;

    void Awake() {
        try {
            playerObject = GameObject.FindWithTag("Player");
            playerBody = playerObject.transform.GetChild(0).gameObject;
            projectileSpawner = playerBody.transform.GetChild(1).transform.GetChild(0).GetComponent<ProjectileSpawner>();
            // animator = GetComponent<Animator>();
        } catch (Exception e) {
            if (debugCount == 0) {
                Debug.Log("Error on Awake(), player is kill: " + e);
                debugCount += 1;
            }
        }
    }

    void Start() {
        scoreHandler = ScoreHandler.singleton;
        healthHandler = HealthHandler.singleton;
        powerupHandler = PowerupHandler.singleton;
        canvasFadeHandler = CanvasFadeHandler.singleton;
        try {
            animator = playerBody.GetComponent<Animator>();
        } catch (Exception e) {
            if (debugCount == 0) {
                Debug.Log("Error on Start(), player is kill: " + e);
                debugCount += 1;
            }
        }
        // unitGetClip = Resources.Load<AudioClip>("UnitGet");
        // audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collisionEntity) {
        try {
            if (entityPrefab.tag == "Document") {
                // Debug.Log("[" + entityPrefab.tag + "] collision with " + collisionEntity.tag);
                if (collisionEntity.tag == "Player") {
                    // code catching animations here i think
                    animator.Play("IdleCatch", 0, 0f);
                    scoreHandler.AddScore(150);
                    Destroy(this.gameObject);
                } else if (collisionEntity.tag == "Despawn") {
                    scoreHandler.DeductScore(5);
                    Destroy(this.gameObject);
                }
            }

            if (entityPrefab.tag == "Damage") {
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

            if (entityPrefab.tag == "Projectile") {
                // Debug.Log("[" + entityPrefab.tag + "] collision with " + collisionEntity.tag);
                // entityPrefab.transform.rotation = projectileSpawner.transform.rotation;
                if (collisionEntity.tag == "Superior") {
                    SuperiorMovement superiorObject = collisionEntity.gameObject.GetComponent<SuperiorMovement>();
                    damage = projectileSpawner.power;
                    
                    superiorObject.DealDamage(damage);
                    Debug.Log("Boss lost [" + damage + "] hp. \nBoss at [" + superiorObject.health + "] hp.");
                    if (superiorObject.health == 0) {
                        Destroy(collisionEntity.gameObject);
                    }

                    // scoreHandler.DeductScore(50);
                    Destroy(this.gameObject);
                } else if (collisionEntity.tag == "Despawn") {
                    Destroy(this.gameObject);
                }
            }
        } catch (Exception e) {
            if (debugCount == 0) {
                Debug.Log("Error on OnTriggerEnter2D(Collider2D collisionEntity), player is kill: " + e);
                debugCount += 1;
            }
        }
    }

    // void OnTriggerExit2D(Collider2D collisionEntity) {
    //     if(entityPrefab.tag == "Edge") {
    //         Debug.Log("[" + entityPrefab.tag + "] collision with " + collisionEntity.tag);
    //     }
    // }
}
