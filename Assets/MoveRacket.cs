using UnityEngine;
using System.Collections;

public class MoveRacket : MonoBehaviour {
    /*
       We will also add a speed variable to our Script, so that we can control the racket's movement speed:
    */
    public float speed = 60;  //We made the speed variable public so that we can always modify it in the Inspector without changing the Script:
    public string axis = "Vertical";
    // Fixed Update method is called over and over again in a fixed time interval. Unity's physics are calculated at exact same time interval.
    void FixedUpdate ()
    {
        /*
        we use GetAxisRaw to check the vertical input axis. 
        This will return 1 when pressing either the W key, the UpArrow key, or when pointing a gamepad's stick upwards.
        It will return -1 when using the S key, the DownArrow key, or when pointing a gamepad's stick downwards.
        It will return 0 when none of those keys are pressed.
        */
        float v = Input.GetAxisRaw(axis);
        /*
        we can use GetComponent to access the racket's Rigidbody component and then set its velocity:
        */
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;
    }
}
