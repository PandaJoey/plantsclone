using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    [SerializeField] int timeToWait = 3;
    int currentSceneIndex;

    // Start is called before the first frame update
    void Start() {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex == 0) {
            StartCoroutine(WaitForTime());
        }
    }

    // Update is called once per frame
    void Update() {

    }

    IEnumerator WaitForTime() {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void RestartScene() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadOptions() {
        SceneManager.LoadScene("Options Screen");
    }

    public void LoadNextScene() {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

   

    public void LoadMainMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }


    public void LoadYouLose() {
        SceneManager.LoadScene("Lose Screen");
    }

    public void Quitgame() {
        Application.Quit();
    }
}

