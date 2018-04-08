using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : MonoBehaviour {

    [SerializeField]
    private GameObject _laserPrefab;


    [SerializeField]
    private float _fireRate = 0.25f;
    private float _canFire = 0.0f; //Used to store the value of the time when the fire can occur

    private bool _leftWall = true;

    // Use this for initialization
    void Start () {

        //Checks if the current object (the object this script attached to) name contains the string mentioned below
        if (transform.name.Contains("RightWallLaserTurret"))
        {
            _leftWall = false;
            
        }
	}
	
	// Update is called once per frame
	void Update () {
        FireLaser();
    }


    private void FireLaser()
    {
        //Checks whether current time is more than value in _canFire variable
        if (Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;
            if (_leftWall)
            {   
                GameObject _laserObj = Instantiate(_laserPrefab, transform.position + new Vector3(-2.5f, 4.7f, 0), Quaternion.identity);
                _laserObj.GetComponent<Laser>().leftWall = true;
            }
            else
            {
                GameObject _laserObj = Instantiate(_laserPrefab, transform.position + new Vector3(-3.5f, 4.61f, 0), Quaternion.identity);
                _laserObj.GetComponent<Laser>().leftWall = false;
            }

        }


    }
}
