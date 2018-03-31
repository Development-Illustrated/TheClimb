using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingFloor : MonoBehaviour {

    //duration the objects waits before getting destroyed
    [SerializeField]
    private int starting_floor_duration = 2;

	// Use this for initialization
	void Start () {
        StartCoroutine(DebrisSpawnRoutine());

    }
	


    //waits for some duration then deletes the current object
    public IEnumerator DebrisSpawnRoutine()
    {
        yield return new WaitForSeconds(starting_floor_duration);
        Destroy(this.gameObject);
    }
}
