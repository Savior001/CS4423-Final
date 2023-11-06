using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/GameInfo")]
public class GameInfoSO : ScriptableObject {
    // [SerializeField] private int initialTimer = 0;
    // [SerializeField] private int initialPhase = 0;
    [SerializeField] private int initialPlayerHP = 100;
    // [SerializeField] private int initialPlayerPP = 0;
    // [SerializeField] private int initialPlayerScore = 0;
    public int timer = 0;
    public int phase = 1;
    public int playerHP = 100;
    public int playerPP = 0;
    public int playerScore = 0;

    // private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;
    void Awake() {
        OnEnable();
    }

    public void OnEnable() {
        playerHP = initialPlayerHP;
    }

    public void DealDamageToPlayer(int damage) {
        playerHP -= damage;
    }
}
