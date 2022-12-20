using System;
using System.Collections;
using System.Collections.Generic;
using PlayerState;
using UnityEngine;

public class PlayerStateful : MonoBehaviour, IStatefull
{
    public CharacterController controller;

    public float speed = 5;
    public float gravity = -9.18f;
    public float jumpHeight = 3f;

    public Rigidbody rb;
    public IPlayerState PlayerState { get; set; }

    internal Vector3 move;
    internal Vector3 velocity;
    bool isGrounded;

    private void Start()
    {
        var gr = new Grounded();
        gr.Init(this);
        PlayerState = gr;
    }

    void Update()
    {
        PlayerState.Ground(controller.isGrounded);
        PlayerState.Update();
        
        
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;
        if (Input.GetKeyDown("left shift"))
        {
            PlayerState.Sprint();
        }
        else
        {
            PlayerState.NonSprint();
        }
        
        controller.Move(move * (speed * Time.deltaTime));
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerState.Up();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            PlayerState.Down();
        }
        velocity.y += gravity * Time.deltaTime;
        
        controller.Move(velocity * Time.deltaTime);
    }

}