using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour {
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject weaponObject;
    [SerializeField] AudioClip stapleClip;
    [SerializeField] public float power = 1f;
    [SerializeField] float speed = 5f;

    public void ShootStaple(Vector3 targetPosition) {
        GetComponent<AudioSource>().PlayOneShot(stapleClip);
        Rigidbody2D newProjectileRB = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
        targetPosition.z = 0;
        Vector3 direction = (targetPosition - transform.position).normalized;
        // Vector3 direction = (targetPosition - transform.position).normalized;
        newProjectileRB.velocity = direction * speed;
    }
}
