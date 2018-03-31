using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpawner : MonoBehaviour
{

    public GameObject world;
    public GameObject platform;
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

                print("platform val: " + platformY[i]);
                print("platform ind: " +i);
                float maxy, miny;
                maxy = (platspawn.transform.position.y) + (platformY[i] * 1.2f);
                miny = (platspawn.transform.position.y) + (platformY[i] * 0.8f);

                float randy = Random.Range(miny, maxy);
                Vector3 platpos = new Vector3(randx, randy, transform.parent.position.z);
                Instantiate(platform.transform, platpos, platform.transform.rotation);
                
            }

            spawned = true;
            
        }

    }
}
