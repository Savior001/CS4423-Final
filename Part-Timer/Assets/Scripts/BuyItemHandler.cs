using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItemHandler : MonoBehaviour {
    public GameInfoSO gameInfoSO;
    ItemSelectHandler itemSelectHandler;

    void Awake() {
        itemSelectHandler = ItemSelectHandler.singleton;
    }

    public void BuyItem() {
        if (gameInfoSO.playerScore > 0 && gameInfoSO.selectedVMItem > 0) {
            if (gameInfoSO.playerScore - itemSelectHandler.vmItems[gameInfoSO.selectedVMItem - 1].price > 0) {
                if (gameInfoSO.playerHP + itemSelectHandler.vmItems[gameInfoSO.selectedVMItem - 1].value > 100) {
                    gameInfoSO.playerHP = 100;
                } else {
                    gameInfoSO.playerHP += itemSelectHandler.vmItems[gameInfoSO.selectedVMItem - 1].value;
                }
                gameInfoSO.playerScore -= itemSelectHandler.vmItems[gameInfoSO.selectedVMItem - 1].price;
            } else {
                Debug.Log("Smell like BROKE!");
            }
            
            // switch(gameInfoSO.selectedVMItem) {
            //     case 1:
            //         if ((gameInfoSO.playerHP + 20) > 100) {
            //             gameInfoSO.playerHP = 100;
            //         } else {
            //             gameInfoSO.playerHP += 20;
            //         }
            //         gameInfoSO.playerScore -= 100;
            //         break;
            //     case 2:
            //         if ((gameInfoSO.playerHP + 30) > 100) {
            //             gameInfoSO.playerHP = 100;
            //         } else {
            //             gameInfoSO.playerHP += 30;
            //         }
            //         gameInfoSO.playerScore -= 100;
            //         break;
            //     case 3:
            //         if ((gameInfoSO.playerHP + 45) > 100) {
            //             gameInfoSO.playerHP = 100;
            //         } else {
            //             gameInfoSO.playerHP += 45;
            //         }
            //         gameInfoSO.playerScore -= 100;
            //         break;
            //     case 4:
            //         if ((gameInfoSO.playerHP + 50) > 100) {
            //             gameInfoSO.playerHP = 100;
            //         } else {
            //             gameInfoSO.playerHP += 50;
            //         }
            //         gameInfoSO.playerScore -= 100;
            //         break;
            //     case 5:
            //         if ((gameInfoSO.playerHP + 10) > 100) {
            //             gameInfoSO.playerHP = 100;
            //         } else {
            //             gameInfoSO.playerHP += 10;
            //         }
            //         gameInfoSO.playerScore -= 100;
            //         break;
            //     case 6:
            //         if ((gameInfoSO.playerHP + 15) > 100) {
            //             gameInfoSO.playerHP = 100;
            //         } else {
            //             gameInfoSO.playerHP += 15;
            //         }
            //         gameInfoSO.playerScore -= 100;
            //         break;
            // }
        }
    }
}
