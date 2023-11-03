using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUpdateHandler : MonoBehaviour {
    public GameInfoSO gameInfoSO;

    public void PlayGame() {
        SceneManager.LoadScene("GameScene");
        gameInfoSO.Disable();
        gameInfoSO.Enable();
    }

    public void QuitGame() {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
