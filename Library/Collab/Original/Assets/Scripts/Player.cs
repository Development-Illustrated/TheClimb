using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float forceupmuli = 1.2f;
    public float forcedirmulti = 0.6f;

    public float force_charge = 0f;
    public float force_charge_multiplier = 200f; // Force multiplier
    public string next_direction;
    public bool can_jump;
    public int default_drag = 0;
    public int wall_drag = 5;
    Rigidbody player_rigidbody;

    public float torque = 100f; // Revolution force for sphere

    [SerializeField]
    private UIManager _uiManager;




    // Use this for initialization
    void Start () {
        player_rigidbody = GetComponent<Rigidbody>();

        //right direction is default
        next_direction = "right";

        can_jump = true;

        //reset user lives
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

       
    }
	
	// Update is called once per frame
	void Update () {

        if (can_jump)
        {

            if (Input.GetKey(KeyCode.Space))
            {
                force_charge += (Time.deltaTime * force_charge_multiplier);
                player_rigidbody.AddTorque(transform.up * force_charge);
            }

            else if (Input.GetKeyUp(KeyCode.Space))
            {
                PlayerJump();

                if (_uiManager != null)
                {
                    _uiManager.UpdateScore();
                }
            }
        }
        
    }

    void PlayerJump()
    {
        Debug.Log("Player just jumped!");

        //freeze the Z position
        player_rigidbody.constraints = RigidbodyConstraints.FreezePositionZ |RigidbodyConstraints.FreezeRotationZ;

        float forceup = force_charge * forceupmuli;
        float forcedir = force_charge * forcedirmulti;


        //Jumps in right direction
        if (next_direction == "right")
        {
            Debug.Log("Right");
            player_rigidbody.AddForce(forcedir, forceup, 0);
            player_rigidbody.AddTorque(transform.right * force_charge * player_rigidbody.velocity.y);

        }
        //Jumps in left direction
        else
        {
            Debug.Log("Left");
            player_rigidbody.AddForce(-forcedir, forceup, 0);
            player_rigidbody.AddTorque(-transform.right * force_charge * player_rigidbody.velocity.y);
            
        }

        //don't let player jump
        can_jump = false;

        //reset rigid body drag
        player_rigidbody.drag = default_drag;

        force_charge = 0;
    }

    void OnCollisionEnter(Collision col)
    {
        //Debug.Log("Collided");
        //Debug.Log(col.gameObject.name);
        Debug.Log("Collided with: "+col.gameObject.tag);

        if (col.gameObject.tag == "Wall")
        {
            //Move the player slightly off the wall so can fall down
            if (next_direction == "right")
            {
                transform.Translate(Vector3.right * .05f);
                next_direction = "left";
            }
            else
            {
                transform.Translate(Vector3.left * .05f);
                next_direction = "right";
            }

            player_rigidbody.AddTorque(transform.up * torque * player_rigidbody.velocity.y);

            //freeze the X,Z position and all rotations
            player_rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;

            //introduce rigid body drag
            player_rigidbody.drag = wall_drag;

            //allow player to jump now
            can_jump = true;

        }
        else if (col.gameObject.tag == "Floor")
        {
            can_jump = true;
            if (next_direction == "right")
            {
                player_rigidbody.AddTorque(transform.right * torque * player_rigidbody.velocity.x);
                player_rigidbody.AddForce(transform.right * 0.2f);

            }
            else
            {
                player_rigidbody.AddTorque(-transform.right * torque * player_rigidbody.velocity.x);
                player_rigidbody.AddForce(-transform.right * 0.2f);

            }

            can_jump = true;
        }

        else if (col.gameObject.tag == "Killer Debris")
        {
            //Destroying player
            Destroy(this.gameObject);
        }
        else if (col.gameObject.tag == "Killer Floor")
        {
            //Destroying player
            //Destroy(this.gameObject);
            KillPlayer();
        }


    }

    void KillPlayer()
    {
        SceneManager.LoadScene("MasterGame");
    }
}
