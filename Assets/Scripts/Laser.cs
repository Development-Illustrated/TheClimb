using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    [SerializeField]
    private float _speed = 10.0f;

    public bool leftWall = true;

    // Use this for initialization
    void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {


        if (leftWall)
        {
            //move speed
            transform.Translate(Vector3.right * _speed * Time.deltaTime);

            //When laser goes off screen, destroy the object (laser)
            if (transform.position.x > 20)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            //move speed
            transform.Translate(Vector3.left * _speed * Time.deltaTime);

            //When laser goes off screen, destroy the object (laser)
            if (transform.position.x < -20)
            {
                Destroy(this.gameObject);
            }
        }

       
    }
}
