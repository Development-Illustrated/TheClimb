using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject player;

    private void LateUpdate()
    {
        if (player)
        {
            Vector3 newPosition = transform.position;
            newPosition.y = player.transform.position.y;
            newPosition.x = player.transform.position.x;
            transform.position = newPosition;

        }

    }
}
