using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class playermove : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float sprintingSpeed = 24f;

    public Transform groundCheck;
    public float groundDistance = 0.6f;
    public LayerMask groundMask;

    Vector3 velocity;

    public bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        //check is at point of groundcheck object, ground distance is the radius of the sphere.
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -10f;
            //0f would work but -2 forces to the ground.
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if(Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            controller.Move(move * sprintingSpeed * Time.deltaTime);
            //Debug.Log("Left shift key is being pressed");
        }
        else
        {
            controller.Move(move * speed * Time.deltaTime);
        }



        //controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -4f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        


    }
}
