using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageColider : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D otherCollider) {
        FindObjectOfType<HealthDisplay>().LoseHealth();

        var attacker = otherCollider.GetComponent<Attacker>();
        if (otherCollider) {
            Destroy(otherCollider.gameObject);
        }
           
    }
}
