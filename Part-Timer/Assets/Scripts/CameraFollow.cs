using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    [SerializeField] Transform playerPos;
    [SerializeField] float smoothTime = 0.3f;
    [SerializeField] float zoom = 2.25f;
    private Vector3 velocity = Vector3.zero;
    public int follow = 0;

    void LateUpdate () {
        if (follow == 0) {
            Vector3 targetPosition = new Vector3(playerPos.position.x, 0, -10);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothTime);
        } else {
            Vector3 targetPosition = new Vector3(GameObject.FindWithTag("VM").transform.position.x, -2.6f, -10f);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothTime);
            GetComponent<Camera>().orthographicSize = zoom;
        }
    }
}
