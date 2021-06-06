using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;

    AttackerSpawner myLaneSpawner;

    Animator animator;

    GameObject projectileParent;

    const string PROJECTILE_PARENTS_NAME = "Projectiles";



    private void Start() {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void Update() {

        if (IsAttackerInLane()) {
            animator.SetBool("isAttacking", true);
        }else {
            animator.SetBool("isAttacking", false);
            
        }
    }

    private void SetLaneSpawner() {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach(AttackerSpawner spawner in spawners) {

            // subtracts the y poisions if 0 in the same lane.
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);

            if(isCloseEnough) {
                myLaneSpawner = spawner;
            }

        }
    }

    private bool IsAttackerInLane() {
        if(myLaneSpawner.transform.childCount <= 0) {
            return false;
        } else {
            return true;
        }
    }
    
    public void Fire() {
        GameObject newProjectile = Instantiate(projectile, gun.transform.position, gun.transform.rotation);
        newProjectile.transform.parent = projectileParent.transform;
        
    }


    private void CreateProjectileParent() {
        projectileParent = GameObject.Find(PROJECTILE_PARENTS_NAME);
        if (!projectileParent) {
            projectileParent = new GameObject(PROJECTILE_PARENTS_NAME);
        }
    }

}

