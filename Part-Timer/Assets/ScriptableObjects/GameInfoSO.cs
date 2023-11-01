using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/GameInfoSO")]
public class GameInfoSO : ScriptableObject {
    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;
    public int timer = 0;
    public int phase = 1;
    public int playerHP = 100;
    public int playerPP = 0;
    public int playerScore = 0;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void DealDamageToPlayer(int damage) {
        playerHP -= damage;
    }
}
