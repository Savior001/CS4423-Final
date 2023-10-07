using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUpdateHandler : MonoBehaviour {
    // GameOverButtons gameOverButtons;

    // void Start() {
    //     gameOverButtons = GameOverButtons.singleton;
    // }

    public void PlayGame() {
        // gameOverButtons.ButtonVisibility(false);
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame() {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void MainMenuy() {
        // gameOverButtons.ButtonVisibility(false);
        SceneManager.LoadScene("MainMenu");
    }
}
