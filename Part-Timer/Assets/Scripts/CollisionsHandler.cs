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
    CanvasFadeHandler canvasFadeHandler;
    Animator animator;
    public GameInfoSO gameInfoSO;
    private int debugCount = 0;
    float damage = 0;
    string previousAnimation = "";

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

    void FixedUpdate() {
        try {
            AnimatorClipInfo[] clip = animator.GetCurrentAnimatorClipInfo(0);
            string currentAnimation = clip[0].clip.name;
            if (previousAnimation != currentAnimation && (previousAnimation.Contains("Catch") && currentAnimation.Contains("Catch"))) {
                animator.SetBool("CTC", true);
            } else {
                animator.SetBool("CTC", false);
            }
            previousAnimation = currentAnimation;
        } catch(NullReferenceException e) {
            if (debugCount == 0) {
                Debug.Log("Error on FixedUpdate(), player is kill: " + e);
                debugCount += 1;
            }
        } catch (MissingReferenceException e) {
            if (debugCount == 0) {
                Debug.Log("Error on FixedUpdate(), player is kill: " + e);
                debugCount += 1;
            }
        }

        // AnimatorClipInfo[] animClipInfo = animator.GetCurrentAnimatorClipInfo(0);

        // if (animatorTimer > 0.4f) {
        //     animator.SetBool("IsCatching", false);
        //     animator.SetBool("CTC", false);
        // }

        // if (animClipInfo[0].clip.name == "RunCatchAnimation" || animClipInfo[0].clip.name == "IdleCatchAnimation") {
        //     // Debug.Log(animClipInfo[0].clip.name + " animaton timer [" + animatorTimer + "]");
        //     if (animatorTimer > 0.4f) {
        //         animator.SetBool("CTC", false);
        //     }
        // }
    }

    void OnTriggerEnter2D(Collider2D collisionEntity) {
        try {
            if (entityPrefab.tag == "Document") {
                // Debug.Log("[" + entityPrefab.tag + "] collision with " + collisionEntity.tag);
                if (collisionEntity.tag == "Player") {
                    // animator.SetBool("IsCatching", true);
                    // animator.SetBool("CTC", true);
                    // animatorTimer = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
                    Rigidbody2D rb = playerObject.GetComponent<Rigidbody2D>();
                    // Debug.Log("Velocity is: " + rb.velocity.x);
                    // code catching animations here i think
                    if (animator.GetFloat("Speed") > 0.01) {
                        if (previousAnimation.Contains("Catch") && previousAnimation != "RunCatch") {
                            animator.SetBool("CTC", true);
                        }
                        animator.Play("RunCatch", 0, 0f);
                    } else {
                        if (previousAnimation.Contains("Catch") && previousAnimation != "IdleCatch") {
                            animator.SetBool("CTC", true);
                        }
                        animator.Play("IdleCatch", 0, 0f);
                    }

                    gameInfoSO.AddScore(150);
                    Destroy(this.gameObject);
                } else if (collisionEntity.tag == "Despawn") {
                    gameInfoSO.DeductScore(5);
                    Destroy(this.gameObject);
                }
            }

            if (entityPrefab.tag == "Damage") {
                // Debug.Log("[" + entityPrefab.tag + "] collision with " + collisionEntity.tag);
                if (collisionEntity.tag == "Player") {

                    if (playerBody.GetComponent<DamageTakenHandler>().playerInvulnerable == 0) {
                        playerBody.GetComponent<DamageTakenHandler>().DamagePlayer();
                        gameInfoSO.DealDamageToPlayer(10);
                        gameInfoSO.DeductScore(50);
                    }

                    if (gameInfoSO.playerHP == 0) {
                        Debug.Log("You ded...");
                        canvasFadeHandler.FadeIn();
                        Destroy(collisionEntity.gameObject);
                    }

                    Destroy(this.gameObject);
                } else if (collisionEntity.tag == "Despawn") {
                    Destroy(this.gameObject);
                }
            }

            if (entityPrefab.tag == "Powerup") {
                // Debug.Log("[" + entityPrefab.tag + "] collision with " + collisionEntity.tag);
                if (collisionEntity.tag == "Player") {
                    // add powerup count or signify type of powerup
                    gameInfoSO.AddPowerup();
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
                    damage = projectileSpawner.getProjectilePower();
                    superiorObject.DealDamage(damage);
                    Debug.Log("Boss lost [" + damage + "] hp. \nBoss at [" + superiorObject.superior.health + "] hp.");
                    
                    if (superiorObject.superior.health <= 0) {
                        Destroy(collisionEntity.gameObject);
                        Debug.Log("A winner is you!");
                        GameObject wallObject = GameObject.FindWithTag("Wall");
                        wallObject.GetComponent<BoxCollider2D>().isTrigger = true;
                        // canvasFadeHandler.FadeIn();
                    }

                    // scoreHandler.DeductScore(50);
                    Destroy(this.gameObject);
                } else if (collisionEntity.tag == "Despawn") {
                    Destroy(this.gameObject);
                }
            }

            if (entityPrefab.tag == "Checkpoint") {
                // Debug.Log("[" + entityPrefab.tag + "] collision with " + collisionEntity.tag);
                if (collisionEntity.tag == "Player") {
                    gameInfoSO.UpdatePhase(3);
                    gameInfoSO.UpdatePlayerMoney();
                    GameObject weaponObject = GameObject.FindWithTag("Weapon");
                    weaponObject.SetActive(false);
                    GameObject cameraObject = GameObject.FindWithTag("MainCamera");
                    cameraObject.GetComponent<CameraFollow>().enabled = true;
                    // canvasFadeHandler.Transition();
                }
            }

            if (entityPrefab.tag == "VM") {
                if (collisionEntity.tag == "Player") {
                    GameObject cameraObject = GameObject.FindWithTag("MainCamera");
                    cameraObject.GetComponent<CameraFollow>().follow = 1;
                    GameObject vmCanvasObj = GameObject.FindWithTag("VMCanvas");
                    vmCanvasObj.GetComponent<CanvasGroup>().alpha = 1;
                }
            }
        } catch (Exception e) {
            if (debugCount == 0) {
                Debug.Log("Error on OnTriggerEnter2D(Collider2D collisionEntity), player is kill: " + e);
                debugCount += 1;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collisionEntity) {

        if (entityPrefab.tag == "Checkpoint") {
            if (collisionEntity.tag == "Player") {
                Debug.Log("[" + entityPrefab.tag + "] collision with " + collisionEntity.tag);
                GameObject wallObject = GameObject.FindWithTag("Wall");
                wallObject.GetComponent<BoxCollider2D>().isTrigger = false;
            }
        }
    }
}
