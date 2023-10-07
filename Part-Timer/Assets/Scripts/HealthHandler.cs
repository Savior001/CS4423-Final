using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHandler : MonoBehaviour {
    Text healthbar;
    [SerializeField] public float hp = 100;
    public static HealthHandler singleton;

    void Awake() {
        if(singleton == null) {
            singleton = this;
        } else {
            Destroy(this.gameObject);
        }
    }

    void Start() {
        healthbar = GetComponent<Text>();
        healthbar.text = hp.ToString();
    }

    public void Regenerate(int regen) {
        hp += regen;
        healthbar.text = hp.ToString();
    }

    public void DealDamage(int damage) {
        hp -= damage;
        healthbar.text = hp.ToString();
    }
}
