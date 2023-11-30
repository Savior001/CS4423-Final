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
        float playerMoney = gameInfoSO.playerMoney;
        bool itemSelected = gameInfoSO.selectedVMItem > 0;
        ItemSelectHandler.VMItem item = itemSelectHandler.vmItems[gameInfoSO.selectedVMItem - 1];

        Debug.Log("Buy button clicked");
        if (playerMoney > 0 && itemSelected) {
            Debug.Log("Player has money and an item is selected");
            if (playerMoney >= item.price) {
                Debug.Log("Player has enough money for selected item");
                if (gameInfoSO.playerHP + item.value > 100) {
                    gameInfoSO.playerHP = 100;
                    Debug.Log("Player health capped at 100");
                } else {
                    gameInfoSO.playerHP += item.value;
                    Debug.Log("Player health increased by " + item.value);
                }

                playerMoney -= (Mathf.Round((item.price) * 100f)) / 100.0f;
                gameInfoSO.playerMoney = playerMoney;
                itemSelectHandler.UpdateText();
            } else {
                vmText.text = "Smell like BROKE in here!";
                Debug.Log("Player does not have enough money for selected item");
            }
        }
    }
}
