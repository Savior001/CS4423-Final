using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    [SerializeField] float health = 100f;
    [SerializeField] float speed = 10f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float wallSlideModifier = 5f;
    [SerializeField] float groundDistance = 1f;
    [SerializeField] float wallDistance = 1f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] LayerMask wallWask;
    [SerializeField] Transform body;
    [SerializeField] AnimationStateChanger animationStateChanger;
    Rigidbody2D rb;
    HealthHandler healthHandler;
    private bool onGround;
    private bool onWall;
    private bool wallSlide => onWall && !onGround && rb.velocity.y < 0f;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        healthHandler = HealthHandler.singleton;
        healthHandler.hp = health;
    }

    void Start() {
    }

    void FixedUpdate() {
        CheckCollisions();
        if (wallSlide) WallSlide();
    }

    public void Move(Vector3 vel) {
        vel *= speed;

        try {
            vel.y = rb.velocity.y;
            rb.velocity = vel;

            if (vel.magnitude > 0) {
                animationStateChanger?.ChangeAnimationState("Run", speed/10);

                if (vel.x > 0) {
                    body.localScale = new Vector3(-1, 1, 1);
                } else if (vel.x < 0) {
                    body.localScale = new Vector3(1, 1, 1);
                }
            } else {
                animationStateChanger?.ChangeAnimationState("Idle");
            }
        } catch (Exception e) {
            //Debug.Log("Error, player is kill: " + e);
        }
    }

    public void Stop(float xvel = 0) {
        rb.velocity = new Vector3(xvel, rb.velocity.y, 0);
        animationStateChanger?.ChangeAnimationState("Idle");
    }

    public void Jump() {
        if (onGround) {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode2D.Impulse);
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
}
