using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
    // Start is called before the first frame update
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;
    [SerializeField] GameObject winLable;
    [SerializeField] GameObject loseLable;
    [SerializeField] float waitToLoad = 4f;

    public void AttackerSpawned() {
        numberOfAttackers++;
    }

    public void AttackerKilled() {     
            numberOfAttackers--;
        if (numberOfAttackers <= 0 && levelTimerFinished) {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition() {
        winLable.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        GetComponent<LevelLoader>().LoadNextScene();
    }

    public void HandleLoseCondition() {
        loseLable.SetActive(true);
        Time.timeScale = 0;
    }

    public void LevelTimerFinished() {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners() {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawnerArray) {
            spawner.StopSpawning();
        }
    }

  


    void Start() {
        winLable.SetActive(false);
        loseLable.SetActive(false);
    }

    // Update is called once per frame
    void Update() {

    }
}

