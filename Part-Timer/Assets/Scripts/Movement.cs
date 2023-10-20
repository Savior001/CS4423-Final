using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    [SerializeField] float health = 100f;
    [SerializeField] public float speed = 5f;
    [SerializeField] public float power = 1f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float wallSlideModifier = 5f;
    [SerializeField] float groundDistance = 1f;
    [SerializeField] float wallDistance = 1f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] LayerMask wallWask;
    [SerializeField] Transform body;
    Rigidbody2D rb;
    HealthHandler healthHandler;
    PowerupHandler powerupHandler;
    private bool onWall;
    private bool wallSlide => onWall && !onGround && rb.velocity.y < 0f;
    private int debugCount = 0;
    public bool onGround = true;
    public Animator animator;
    AnimatorClipInfo[] animatorClipInfo;
    string animatorClipName = "";
    string previousClipName = null;
    float animatorClipLength;
    float animatorClipTime;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        healthHandler = HealthHandler.singleton;
        powerupHandler = PowerupHandler.singleton;
        healthHandler.hp = health;
        powerupHandler.playerSpeed = speed;
    }

    void Start() {
    }

    void FixedUpdate() {
        previousClipName = animatorClipName;
        animatorClipInfo = animator.GetCurrentAnimatorClipInfo(0);
        animatorClipName = animatorClipInfo[0].clip.name;
        animatorClipLength = animatorClipInfo[0].clip.length;
        animatorClipTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

        var newSpeed = powerupHandler.playerSpeed;

        CheckCollisions();
        if (onGround) {
            animator.SetBool("IsFalling", false);
        } else {
            if (rb.velocity.y <= 0) {
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsFalling", true);
            }
            // Debug.Log("current y vel: " + rb.velocity.y);
        }

        if (wallSlide) { WallSlide(); }
        if (speed < newSpeed) {
            speed = newSpeed;
            Debug.Log("new speed: " + speed);
        }

        if (!onGround && rb.velocity.y <= 0) {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", true);
        }
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    public void Move(Vector3 vel) {
        vel *= speed;

        try {
            vel.y = rb.velocity.y;
            rb.velocity = vel;

            if (vel.magnitude > 0) {
                if (vel.x > 0) {
                    body.localScale = new Vector3(-1, 1, 1);
                } else if (vel.x < 0) {
                    body.localScale = new Vector3(1, 1, 1);
                }
            }
        } catch (Exception e) {
            if (debugCount == 0) {
                Debug.Log("Error on Move(Vector3 call), player is kill: " + e);
                debugCount += 1;
            }
        }
    }

    public void Stop(float xvel = 0) {
        rb.velocity = new Vector3(xvel, rb.velocity.y, 0);
        Debug.Log("Previous animation: " + previousClipName);
        Debug.Log("Current animation: " + animatorClipName);
        if (animatorClipName == "RunCatch") {
            animator.Play("IdleCatch", 0, animatorClipTime);
            Debug.Log("Switching animation to [" + animatorClipName + "] from ["
                + previousClipName + "]\nat normailzedTime of: " + animatorClipTime);
        }
        // if (animatorClipName != null && animatorClipName.Contains("Catch") && previousClipName != animatorClipName) {
        //     if (previousClipName == "RunCatch") {
        //         animator.Play("IdleCatch", 0, animatorClipTime);
        //         Debug.Log("Switching animation to [" + animatorClipName + "] from ["
        //             + previousClipName + "]\nat normailzedTime of: " + animatorClipTime);
        //     }
        // }
    }

    public void Jump() {
        if (onGround) {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode2D.Impulse);
            animator.SetBool("IsJumping", true);
        }
        // if (Physics2D.OverlapCircleAll(transform.position - new Vector3(0, 0.5f, 0), groundDistance, groundMask).Length > 0) {
        //     rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode2D.Impulse);
        // } else {
        //     Debug.Log("Can't jump!\nOverlap with ground is: " + Physics2D.OverlapCircleAll(transform.position - new Vector3(0, 0.5f, 0), groundDistance, groundMask).Length + " which is not > 0");
        // }
    }

    public void WallSlide() {
        rb.velocity = new Vector3(rb.velocity.x, -speed * wallSlideModifier);
    }

    private void CheckCollisions() {
        onGround = Physics2D.OverlapCircleAll(transform.position - new Vector3(0, 0.5f, 0), groundDistance, groundMask).Length > 0;
        onWall = Physics2D.OverlapCircleAll(transform.position - new Vector3(0, 0.5f, 0), wallDistance, wallWask).Length > 0;
    }

    // used to draw collisions check wire frame
    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position - new Vector3(0, .5f, 0), groundDistance);
    }
}
