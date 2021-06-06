using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour {
    [SerializeField] float damage = 50f;


    private void OnTriggerEnter2D(Collider2D othercCollider) {
        GameObject otherObject = othercCollider.gameObject;

        if (otherObject.GetComponent<Defender>()) {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
