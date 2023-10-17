using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour {
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject weaponObject;
    [SerializeField] float speed = 5f;

    public void SpawnProjectile(Vector3 targetPosition) {
        Rigidbody2D newProjectileRB = Instantiate(projectilePrefab, weaponObject.transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
        targetPosition.z = 0;
        Vector3 direction = (targetPosition - transform.position).normalized;
        newProjectileRB.velocity = direction * speed;
    }
}
