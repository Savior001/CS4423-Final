using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUpdateHandler : MonoBehaviour {
    [SerializeField] Movement movement;
    [SerializeField] FallingPapersEffect fpe;
    public GameInfoSO gameInfoSO;

    public void PlayGame() {
        SceneManager.LoadScene("GameScene");
        // gameInfoSO.Disable();
        gameInfoSO.OnEnable();
    }

    public void QuitGame() {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void NextLevel() {
        MovePlayer();
        gameInfoSO.NextLevel();
        SceneManager.LoadScene("GameScene");
        GameObject vmCanvasObj = GameObject.FindWithTag("VMCanvas");
        GameObject vmPromptObj = vmCanvasObj.transform.Find("VMPrompt").gameObject;
        vmCanvasObj.GetComponent<Canvas>().enabled = false;
        vmPromptObj.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
        gameInfoSO.OnEnable();
    }

    void MovePlayer() {
        StartCoroutine(MovePlayerCoroutine());

        IEnumerator MovePlayerCoroutine() {
            while(true) {
                movement.Move(new Vector3(1, 0, 0));
                fpe.ActivateEffect(new Vector3(1, 0, 0));
                yield return null;
            }
        }
    }
}
