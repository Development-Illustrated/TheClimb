using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpawner : MonoBehaviour
{

    public GameObject background;
    private bool spawned;



    // If player hits a collider, get the parent position (parent = Ground)
    // Then spawn a new 'ground' object with the same rotation but lower.
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !spawned)
        {
            Vector3 pos = new Vector3(transform.parent.position.x, (transform.parent.position.y + 20f), transform.parent.position.z);
            Instantiate(background.transform, pos, transform.parent.rotation);
            spawned = true;
        }

    }
}
