using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    [Range(0f, 5f)]
    float currentSpeed = 1f;
    GameObject currentTarget;




    // Update is called once per frame
    void Update() {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();

    }

    private void Awake() {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy() {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController != null) {
            levelController.AttackerKilled();
        }
    }

    public void SetMovementSpeed(float speed) {
        currentSpeed = speed;

    }

    public void Attack(GameObject target) {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage) {

        Health health = currentTarget.GetComponent<Health>();
        if (health) {
            health.DealDamage(damage);
        }

    }

    private void UpdateAnimationState() {
        if (!currentTarget) {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }
}

   
