using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;
    public float smoothTime;
    Vector3 currentVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 followPosition = new Vector3(
                player.position.x,
                player.position.y,
                transform.position.z
            );

        transform.position = Vector3.SmoothDamp(transform.position,
            followPosition, 
            ref currentVelocity, 
            smoothTime);
    }
}
