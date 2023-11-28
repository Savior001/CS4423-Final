using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/SuperiorInfo")]
public class SuperiorInfoSO : ScriptableObject {
    TimerText timerText;
    public float health;
    public float speed;
    public float moveSpeedMultiplier;
    public float timerStop;

    // private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;
    void Awake() {
        OnEnable();
    }

    public void OnEnable() {
        // LoadSuperiorStats();
    }

    public void LoadSuperiorStats(float h, float s, float msm, float ts) {
        health = h;
        speed = s;
        moveSpeedMultiplier = msm;
        timerStop = ts;
    }

    public void DealDamage(float damage) {
        health -= damage;
    }
}
