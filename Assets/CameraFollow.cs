using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraFollow : MonoBehaviour
{
  
    public float FollowSpeed = 2f; //this controls how fast the camera follows the player
    public Transform target; 

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3( //this creates a new position for the camera using the targets x and y position
            target.position.x, //x
            target.position.y, //y
            -10f               //the z is set to -10 so the camera stays infront of the scene and not behind any objects
            ); 
                                                                                
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime); //this moves the camera from one position to another, lerp makes it so the movement is smooth instead of snappy
    }
}
