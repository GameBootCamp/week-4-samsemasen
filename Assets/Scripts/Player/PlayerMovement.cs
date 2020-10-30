using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;

    Vector3 velocity;

    public Transform grounCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;


    void Update()
    {
        //check if grounded and reset velocity.y
        isGrounded = Physics.CheckSphere(grounCheck.position, groundDistance, groundMask);

        if(isGrounded&& velocity.y < 0) {
            velocity.y = -2f;
        }

        // get the input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // player movement
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        //jump // physics formula --> v = SquareRoot(h * -2 * g)
        if (Input.GetButtonDown("Jump") && isGrounded) { // default jump button is space button
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // aplying gravity // physics of free fall (deltaY = 1/2 * g * t^2 )
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
}
