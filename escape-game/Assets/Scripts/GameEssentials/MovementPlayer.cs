using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 10;
    public float gravity = 40f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    void Start()
    {
        // Setzen der gespeicherten Spieler-Position
        controller.enabled = false;
        transform.position = SaveScript.PlayerPosition;
        transform.rotation = Quaternion.Euler(0f, SaveScript.PlayerRotationY, 0f);
        controller.enabled = true;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * moveX + transform.forward * moveY;
        movement *= Time.deltaTime * speed;

        controller.Move(movement);
    }
}
