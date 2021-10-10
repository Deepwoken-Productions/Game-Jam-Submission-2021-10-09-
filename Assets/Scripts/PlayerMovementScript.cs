using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public CharacterController controller;

    public float speed;
    public float jumpHeight;
    public float gravity = -9.8f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    //Check what it shoud collide with
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        //Creates a tiny sphere that returns whether it colldies with anything not whitelisted.
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            //Forces player on ground
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Don't define a new vector as those are global co-ordinates
        Vector3 move = transform.right * x + transform.forward * z; // Similar to Unreal

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButton("Jump") && isGrounded)
        {
            //Expensive op
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

}
