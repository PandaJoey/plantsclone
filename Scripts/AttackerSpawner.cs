using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {

    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[]  attackerPrefabArray;
    float numberOfAttackers;
   
    bool spawn = true;



    
   IEnumerator Start() {

        ChangeSpawnTimer();
        while (spawn) {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
            
        }
        
    }

    public void StopSpawning() {
        spawn = false;
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void SpawnAttacker() {
        var attackerInxed = Random.Range(0, attackerPrefabArray.Length);
        Spawn(attackerPrefabArray[attackerInxed]);       
    }

    private void Spawn(Attacker myAttacker) {

        Attacker newAttacker = Instantiate(myAttacker, transform.position, transform.rotation) as Attacker;
        //how to spawn the objects inside the parents so we can keep it undercontrol and use it later to
        //decide weather a defender needs to shoot or not
        newAttacker.transform.parent = transform;
        
    }

    public void ChangeSpawnTimer() {
        if(PlayerPrefsController.GetDifficulty() == 0) {
            minSpawnDelay = 7f;
            maxSpawnDelay = 15f;
        }else if (PlayerPrefsController.GetDifficulty() == 1) {
            minSpawnDelay = 5f;
            maxSpawnDelay = 10f;
        }else if (PlayerPrefsController.GetDifficulty() == 2) {
            minSpawnDelay = 2f;
            maxSpawnDelay = 5f;
        }
    }


}
