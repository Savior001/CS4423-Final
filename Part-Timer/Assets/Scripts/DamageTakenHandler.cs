using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTakenHandler : MonoBehaviour {
    [SerializeField] GameObject playerBodyObj;
    [SerializeField] float initialInvulTimer = 0.25f;
    [SerializeField] float invulnerableTimer = 0.25f;
    [SerializeField] float playerAlphaValue = 0.1f;
    public int playerInvulnerable = 0;

    public void DamagePlayer() {
        // Debug.Log("Player invulnerable due to damage");
        playerInvulnerable = 1;
        StartCoroutine(PlayerDamagedCoroutine());

        IEnumerator PlayerDamagedCoroutine() {
            Color playerColor = playerBodyObj.GetComponent<SpriteRenderer>().color;
            while (invulnerableTimer > 0f) {
                invulnerableTimer -= Time.deltaTime;
                // Debug.Log("invulnerable timer: " + invulnerableTimer);
                playerColor.a = playerAlphaValue;
                playerBodyObj.GetComponent<SpriteRenderer>().color = playerColor;
                yield return new WaitForSeconds(0.125f);
                playerColor.a = 255f;
                playerBodyObj.GetComponent<SpriteRenderer>().color = playerColor;
                yield return null;
            }
            // Debug.Log("Player vulnerable");
            invulnerableTimer = initialInvulTimer;
            playerInvulnerable = 0;
        }
    }
}
