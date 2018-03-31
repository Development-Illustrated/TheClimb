using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerFloor : MonoBehaviour {

    //Speed of how quickly Killer Floor moves up
    public float floor_speed = .1f;
    public bool game_running = false;
    public GameObject player;
    float playerstarty;

    // Use this for initialization
    void Start () {

        playerstarty = player.transform.position.y;
        		
	}
	
	// Update is called once per frame
	void Update () {
        if (player.transform.position.y > playerstarty)
        {
            game_running = true;
        }

        if (game_running == true)
        {
            transform.Translate(Vector3.up * floor_speed);
        }
                
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            game_running = false;
        }
    }
}
