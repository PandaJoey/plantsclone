using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    [Tooltip("Our Level Timer In Seconds")]
    [SerializeField] float levelTime = 100f;
    bool triggeredLevelFinsihed = false;

    // Update is called once per frame
    void Update() {

        if(triggeredLevelFinsihed) {
            return;
        }

        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if(timerFinished) {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinsihed = true;
        }
    }
}
