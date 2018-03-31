using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject[] DebrisSelection;

    [SerializeField]
    private int DebrisDelay = 3;

    [SerializeField]
    private GameObject Player;

    void Start()
    {

        StartCoroutine(DebrisSpawnRoutine());

    }


    //create a coroutine to spawn the Enemy every 5 seconds
    public IEnumerator DebrisSpawnRoutine()
    {
        while (true)
        {
            SpawnDebris();
            yield return new WaitForSeconds(DebrisDelay);
        }

    }

    public void SpawnDebris()
    {
        if (Player != null)
        {
            //getting player's current position
            Vector3 playerPosition = Player.transform.position;

            //Spawning debris randomly above the player
            Vector3 spawnPosition = new Vector3(Random.Range(-2f, 2f), playerPosition.y + 10f, 0);

            //Randomly selecting the debri to spawn
            GameObject debris = DebrisSelection[Random.Range(0, DebrisSelection.Length)];
            
            //Instantiates debris with random rotation
            Instantiate(debris, spawnPosition, Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), 0));
        }
        
    }
}
