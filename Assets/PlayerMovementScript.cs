using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

    Vector3 velocity;
    public LayerMask groundMask;
    public CharacterController controller;
    public Transform groundcheck;
    public float groundDistance = 0.4f;
    public float jumpHeight = 3f;
    public bool isRunning;
    bool isGrounded;
    public float gravity = -8.36f;
    public float speed;
    public float runSpeed = 20f;
    public float normalSpeed = 12f;
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask); //creates a sphere to check if on ground
        if(isGrounded && velocity.y < 0) {
            velocity.y = -2f;

        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if(Input.GetKey(KeyCode.LeftShift)) {
            isRunning = true;
            speed = runSpeed;
        } else {
            isRunning = false;
            speed = normalSpeed;

        }

        print(speed);

        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        

        if(Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }



    }
}
