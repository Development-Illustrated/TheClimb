using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisDestroyer : MonoBehaviour {

    //Destroys the debris once it collides with Killer Floor
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Killer Floor")
        {
            Destroy(this.gameObject);
        }
    }
}
