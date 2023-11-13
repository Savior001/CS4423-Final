using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/GameInfo")]
public class GameInfoSO : ScriptableObject {
    TimerText timerText;
    [SerializeField] private int initialTimer = 0;
    [SerializeField] private int initialPhase = 0;
    [SerializeField] private int initialPlayerHP = 100;
    [SerializeField] private float initialPlayerPP = 0;
    [SerializeField] private float initialPlayerSpeed = 6;
    [SerializeField] private float initialPlayerPower = 1f;
    [SerializeField] private int initialPlayerScore = 0;
    public int timer = 0;
    public int phase = 1;
    public int playerHP = 100;
    public float playerPP = 0;
    public float playerSpeed = 5;
    public float playerPower = 1;
    public int playerScore = 0;

    // private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;
    void Awake() {
        OnEnable();
    }

    void FixedUpdate() {
        timer = timerText.seconds;
    }

    public void OnEnable() {
        timer = initialTimer;
        phase = initialPhase;
        playerHP = initialPlayerHP;
        playerPP = initialPlayerPP;
        playerSpeed = initialPlayerSpeed;
        playerScore = initialPlayerScore;
    }

    public void DealDamageToPlayer(int damage) {
        playerHP -= damage;
    }

    public void AddScore(int p) {
        playerScore += p;
    }

    public void DeductScore(int p) {
        if (playerScore - p < 0) {
            playerScore = 0;
        } else {
            playerScore -= p;
        }
    }

    public void AddPowerup() {
        playerPP += 1f;
        playerSpeed = initialPlayerSpeed + (playerPP * 0.25f);
        playerPower = initialPlayerPower + (playerPP * 0.25f);
    }
}
