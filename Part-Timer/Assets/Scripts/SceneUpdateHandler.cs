using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUpdateHandler : MonoBehaviour {
    public void PlayGame() {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame() {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
