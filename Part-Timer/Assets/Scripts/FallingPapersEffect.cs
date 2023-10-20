using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPapersEffect : MonoBehaviour {
    [SerializeField] Movement playerMovement;
    ParticleSystem particleSystem = new ParticleSystem();
    
    void Start() {
        particleSystem = GetComponent<ParticleSystem>();
    }

    void FixedUpdate() {
        var emission = particleSystem.emission;
        emission.rateOverDistance = playerMovement.speed * 0.035f;
    }
    
    public void ActivateEffect(Vector3 vel) {
        var emission = particleSystem.emission;
        if (vel.magnitude > 0) {
            emission.enabled = true;
        } else {
            emission.enabled = false;
        }
    }
}
