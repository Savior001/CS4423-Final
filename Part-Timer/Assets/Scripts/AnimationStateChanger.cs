using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateChanger : MonoBehaviour {
    [SerializeField] Animator animator;
    [SerializeField] public string currentState = "Idle";
    public static AnimationStateChanger singleton;

    void Awake() {
        if(singleton == null) {
            singleton = this;
        } else {
            Destroy(this.gameObject);
        }
    }

    void Start() {
        ChangeAnimationState(currentState);
    }

    void Update() {

    }

    public void ChangeAnimationState(string newAnimationState, float speed = 1) {
        // Debug.Log("newAnimation is: " + newAnimationState);
        animator.speed = speed;

        if (newAnimationState == currentState) {
            return;
        }

        currentState = newAnimationState;
        animator.Play(currentState);
    }
}
