using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateChanger : MonoBehaviour {
    [SerializeField] Animator animator;
    [SerializeField] public string currentAnimationState = "Idle";
    public static AnimationStateChanger singleton;

    void Awake() {
        if(singleton == null) {
            singleton = this;
        } else {
            Destroy(this.gameObject);
        }
    }

    void Start() {
        ChangeAnimationState(currentAnimationState);
    }

    void Update() {

    }

    public void ChangeAnimationState(string newAnimationState, float speed = 1) {
        
        animator.speed = speed;
        if (newAnimationState == currentAnimationState) {
            return;
        }
        Debug.Log("currentAnimation is: " + currentAnimationState);
        Debug.Log("newAnimation is: " + newAnimationState);
        
        if(currentAnimationState == "RunCatch" && (newAnimationState == "Idle" || newAnimationState == "Run")) {
            Debug.Log("something");
            return;
        }

        if ((currentAnimationState == "IdleCatch" || currentAnimationState == "RunCatch") &&
            (newAnimationState == "IdleCatch" || newAnimationState == "RunCatch")) {
            animator.SetBool("CTC", true);
        } else if (newAnimationState == currentAnimationState) {
            animator.SetBool("CTC", false);
            return;
        }
        
        currentAnimationState = newAnimationState;
        animator.Play(currentAnimationState);
    }
}
