using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour {
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject playerObject;
    [SerializeField] GameObject weaponObject;
    [SerializeField] AudioClip stapleClip;
    float speed = 5f;
    float power = 1f;

    void FixedUpdate() {
    }

    public void ShootStaple(Vector3 targetPosition) {
        speed += playerObject.GetComponent<Movement>().power;
        power = playerObject.GetComponent<Movement>().power;
        GetComponent<AudioSource>().PlayOneShot(stapleClip);
        Rigidbody2D newProjectileRB = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
        targetPosition.z = 0;
        Vector3 direction = (targetPosition - transform.position).normalized;
        // Vector3 direction = (targetPosition - transform.position).normalized;
        newProjectileRB.velocity = direction * speed;
    }

    public float getProjectilePower() {
        return this.power;
    }
}
