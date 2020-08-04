using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    public float speed = 1f;
    public float gravity = -9.8f;
    private CharacterController _charController;

    private void Start()
    {
        _charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //get keyboard input * speed
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        // translate to movement
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        // limit diagonal movement to speed of movement
        movement = Vector3.ClampMagnitude(movement, speed);
        // apply gravity
        movement.y = gravity;
        // framerate independant movement
        movement *= Time.deltaTime;
        // transform movement vector from local to gloabl coords
        movement = transform.TransformDirection(movement);
        // apply movement via character controller component
        _charController.Move(movement);
    }
}
