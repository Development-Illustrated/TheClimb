using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    public float minY = 25f;

    private void LateUpdate()
    {
        if (player)
        {
            Vector3 newPosition = transform.position;
            if (player.transform.position.y >= minY)
            {
                newPosition.y = player.transform.position.y;

                //newPosition.x = player.transform.position.x;
                transform.position = newPosition;

            }

            transform.LookAt(player.transform);

        }

    }
}
