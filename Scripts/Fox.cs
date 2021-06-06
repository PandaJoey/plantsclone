using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour {

    [SerializeField] float damage = 100f;
    GameObject gravestone;


    private void OnTriggerEnter2D(Collider2D othercCollider) {
        GameObject otherObject = othercCollider.gameObject;

        if (otherObject.GetComponent<Gravestone>()) {
            GetComponent<Animator>().SetTrigger("jumpTrigger");
        } else if (otherObject.GetComponent<Defender>()) {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }

    // Start is called before the first frame update
    void Start() {
        gravestone = GameObject.Find("GraveStone");
    }

    // Update is called once per frame
    void Update() {

    }
}
