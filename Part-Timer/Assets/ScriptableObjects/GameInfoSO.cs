using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/GameInfo")]
public class GameInfoSO : ScriptableObject {
    TimerText timerText;
    [SerializeField] private int initialTimer = 0;
    [SerializeField] private int initialPhase = 1;
    [SerializeField] private int initialPlayerHP = 100;
    [SerializeField] private float initialPlayerPP = 0f;
    [SerializeField] private float initialPlayerSpeed = 6;
    [SerializeField] private float initialPlayerPower = 1f;
    [SerializeField] private float initialPlayerScore = 0f;
    [SerializeField] private int initialSelectedVMItem = 0;
    [SerializeField] private int initialLevel = 1;
    public int timer = 0;
    public int phase = 1;
    public int playerHP = 100;
    public float playerPP = 0f;
    public float playerSpeed = 5f;
    public float playerPower = 1f;
    public float playerScore = 0f;
    public float playerMoney = 0f;
    public int selectedVMItem = 0;
    public int level = 1;

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
        selectedVMItem = initialSelectedVMItem;
        level = initialLevel;
    }

    public void DealDamageToPlayer(int damage) {
        playerHP -= damage;
    }

    public void AddScore(float p) {
        playerScore += p;
    }

    public void DeductScore(float p) {
        if (playerScore - p < 0) {
            playerScore = 0f;
        } else {
            playerScore -= p;
        }
    }

    public void AddPowerup() {
        playerPP += 1f;
        playerSpeed = initialPlayerSpeed + (playerPP * 0.25f);
        playerPower = initialPlayerPower + (playerPP * 0.25f);
    }

    public void SelectVMItem(int i) {
        selectedVMItem = i;
    }

    public void UpdatePhase(int p) {
        phase = p;
    }

    public void UpdatePlayerMoney() {
        float amount = playerScore - (playerScore * .9f);
        playerMoney = (Mathf.Round(amount * 100f)) / 100.0f;
        Debug.Log("-Taxes\n-401k\n-Health Coverage\n$ " + playerMoney);
        if (playerMoney > 15f) {
            playerMoney = (Mathf.Round((playerMoney * .05f) * 100f)) / 100.0f;
            Debug.Log("-Just because lol\n$ " + playerMoney);
        }
    }

    public void NextLevel() {
        playerScore = initialPlayerScore;
        level += 1;
        phase = 1;
    }
}
