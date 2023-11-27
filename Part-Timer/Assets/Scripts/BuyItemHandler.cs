using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyItemHandler : MonoBehaviour {
    [SerializeField] Text vmText;
    public GameInfoSO gameInfoSO;
    ItemSelectHandler itemSelectHandler;

    void Awake() {
        itemSelectHandler = ItemSelectHandler.singleton;
    }

    public void BuyItem() {
        if (gameInfoSO.playerMoney > 0 && gameInfoSO.selectedVMItem > 0) {
            if (gameInfoSO.playerMoney - itemSelectHandler.vmItems[gameInfoSO.selectedVMItem - 1].price > 0) {
                if (gameInfoSO.playerHP + itemSelectHandler.vmItems[gameInfoSO.selectedVMItem - 1].value > 100) {
                    gameInfoSO.playerHP = 100;
                } else {
                    gameInfoSO.playerHP += itemSelectHandler.vmItems[gameInfoSO.selectedVMItem - 1].value;
                }
                gameInfoSO.playerMoney -= itemSelectHandler.vmItems[gameInfoSO.selectedVMItem - 1].price;
            } else {
                vmText.text = "Smell like BROKE in here!";
                Debug.Log("Smell like BROKE!");
            }
        }
    }
}
