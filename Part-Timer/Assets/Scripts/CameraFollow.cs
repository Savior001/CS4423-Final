using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    [SerializeField] Transform playerPos;
    [SerializeField] float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    void LateUpdate () {
        Vector3 targetPosition = new Vector3(playerPos.position.x, 0, -10);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothTime);
    }
}
