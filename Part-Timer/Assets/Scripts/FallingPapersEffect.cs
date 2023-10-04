using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPapersEffect : MonoBehaviour {
    [SerializeField] GameObject entityPrefab;
    ParticleSystem particleSystem;
    
    void Start() {
        particleSystem = GetComponent<ParticleSystem>();
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
