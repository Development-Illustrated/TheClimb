using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    private void OnTriggerEnter(Collider col)
    { 
        if (col.gameObject.tag == "Player")
        {
            Rigidbody player = GameObject.Find("Player").GetComponent<Rigidbody>();
            if (player.velocity.y > 0f)
            {
                Debug.Log("Collider has been hit while player is moving up");
                transform.parent.GetComponentInParent<BoxCollider>().enabled = false;
                Debug.Log("Parent collider should be stopped");
            }

        }

    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            transform.parent.GetComponentInParent<BoxCollider>().enabled = true;
        }
    }
}
