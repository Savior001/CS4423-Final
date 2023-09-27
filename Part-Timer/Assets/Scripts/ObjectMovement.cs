using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour {
    [SerializeField] GameObject entityPrefab;
    [SerializeField] float speed = 2f;
    private int number = 0;
    
    void Update() {
        Vector3 vel = Vector3.zero;
        number = Random.Range(0, 1);
        
        vel.y = -1;
        
        transform.position += vel * (speed + Random.Range(1.5f, 3)) * Time.deltaTime;

        if(entityPrefab.tag == "Damage") {
            if(number == 0)
                transform.Rotate(Vector3.forward);
            else
                transform.Rotate(Vector3.back);
        }
    }
}
