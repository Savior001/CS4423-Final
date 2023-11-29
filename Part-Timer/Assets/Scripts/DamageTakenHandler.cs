using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTakenHandler : MonoBehaviour {
    void DamagePlayer() {
        StartCoroutine(PlayerDamagedCoroutine());

        IEnumerator PlayerDamagedCoroutine() {
            Debug.Log("Running damage coroutine");
            while (true) {
                yield return new WaitForSeconds(1f);
                Debug.Log("Running while loop");
                if (transform.GetComponent<SpriteRenderer>().enabled == true) {
                    transform.GetComponent<SpriteRenderer>().enabled = false;
                } 
                transform.GetComponent<SpriteRenderer>().enabled = true;
                yield return null;
            }
        }
    }
}
