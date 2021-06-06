using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {
    [SerializeField] int starCost = 25;
    StarDisplay addStars;

    public void AddStars(int amount) {
        FindObjectOfType<StarDisplay>().AddStars(amount);
    }

    public int GetStarCost() {
        return starCost;
    }

}

