using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour {

    [SerializeField] float baseLives = 3;
    [SerializeField] int damage = 1;

    float healthRemaining;
    Text healthText;

    
   
    void Start() {

        healthRemaining = baseLives - PlayerPrefsController.GetDifficulty();
        Debug.Log("Difficulty setting current is " + PlayerPrefsController.GetDifficulty());
        healthText = GetComponent<Text>();
        UpdateDisplay();
        
    }

    private void UpdateDisplay() {
        healthText.text = healthRemaining.ToString();
    }

    public bool HaveEnoughHealth(int amount) {
        return healthRemaining >= amount;
    }


    public void LoseHealth() {
        
            healthRemaining -= damage;
            UpdateDisplay();

        if(healthRemaining <= 0) {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    
        
    }




}
