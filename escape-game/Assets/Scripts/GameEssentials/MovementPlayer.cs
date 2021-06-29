using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

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
        transform.position = SaveScript.playerPosition;
        transform.rotation = Quaternion.Euler(0f, SaveScript.playerRotationY, 0f);
        controller.enabled = true;
    }

    void Update()
    {
        // Gravitation
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Erkennen der Bewegungseingabe
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Bewegung des Spielenden
        Vector3 movement = transform.right * moveX + transform.forward * moveY;

        // Schnellere Bewegung nach einsammeln der Brille
        if (!SaveScript.glassesCollected)
        {
            movement *= Time.deltaTime * (speed / 2);
        }
        else
        {
            movement *= Time.deltaTime * speed;
        }

        // Zuweisung der Bewegung zu Objekt 
        controller.Move(movement);
    }
}