using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour {
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject playerObject;
    [SerializeField] GameObject weaponObject;
    [SerializeField] AudioClip stapleClip;
    [SerializeField] int staplesPoolCap = 50;
    public List<Rigidbody2D> staplesPool;
    public GameInfoSO gameInfoSO;
    float speed = 5f;
    float power = 1f;

    void Start() {
        staplesPool = new List<Rigidbody2D>();
    }

    public void ShootStaple(Vector3 targetPosition) {
        speed = gameInfoSO.playerSpeed;
        power = gameInfoSO.playerPower;
        GetComponent<AudioSource>().PlayOneShot(stapleClip);
        Rigidbody2D newProjectileRB;// = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
        
        if (staplesPool.Count > staplesPoolCap) {
            staplesPool.RemoveAt(0);
            newProjectileRB = staplesPool[0];
            newProjectileRB.transform.position = transform.position;
        } else {
            newProjectileRB = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
        }

        staplesPool.Add(newProjectileRB);
        targetPosition.z = 0;
        Vector3 direction = (targetPosition - transform.position).normalized;
        // Vector3 direction = (targetPosition - transform.position).normalized;
        newProjectileRB.velocity = direction * speed;
    }

    public float getProjectilePower() {
        return this.power;
    }
}
