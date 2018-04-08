using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpawner : MonoBehaviour
{

    public GameObject world;
    public GameObject platform;
    public GameObject[] LaserTurrets;
    private bool spawned;
    public float[] platformY = {20f, 32f, 47f};



    // If player hits a collider, get the parent position (parent = Ground)
    // Then spawn a new 'ground' object with the same rotation but lower.
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !spawned)
        {
            Vector3 pos = new Vector3(transform.parent.position.x, (transform.parent.position.y + 55.5f), transform.parent.position.z);
            Instantiate(world.transform, pos, transform.parent.rotation);

            for(int i = 0; i < platformY.Length; i++)
            {

                Transform platspawn = world.transform.Find("Game World Spawn Manager").gameObject.transform;

                
                // Position platform up to 30% to the left or right of the centre
                float randx = Random.Range(platspawn.position.x * 0.1f, platspawn.position.x * 1.9f);   
                float maxy, miny;
                maxy = (platspawn.transform.position.y) + (platformY[i] * 1.2f);
                miny = (platspawn.transform.position.y) + (platformY[i] * 0.8f);

                float randy = Random.Range(miny, maxy);
                Vector3 platpos = new Vector3(randx, randy, transform.parent.position.z);
                Instantiate(platform.transform, platpos, platform.transform.rotation);


                randy = Random.Range(miny, maxy);
                SpawnTurret(randy);
                
            }

            spawned = true;
            
        }

    }


    //Spawns a laser wall turret given a y position
    private void SpawnTurret(float y)
    {

        //Randomnly chooses one of the turrets (left wall or right wall)
        int turrentID = Random.Range(0, LaserTurrets.Length);

        Debug.Log(LaserTurrets[turrentID].name);

        if (LaserTurrets[turrentID].name == "RightWallLaserTurret")
        {
            Debug.Log("Spawning: " + LaserTurrets[turrentID].name);
            Vector3 TurretPos = new Vector3(19.88f, y, -27);
            Instantiate(LaserTurrets[turrentID], TurretPos, Quaternion.identity);        
        }
        else
        {
            Debug.Log("Spawning: " + LaserTurrets[turrentID].name);
            Vector3 TurretPos = new Vector3(0, y, -27);
            Instantiate(LaserTurrets[turrentID], TurretPos, Quaternion.identity); 
        }

        

        
    }
}
