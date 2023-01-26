using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public Vector2 friction = new Vector2(-.1f, 0);
    public float speed;
    public float speedRun;
    public float jumpForce = 5;

    private float _currentSpeed;

    private void Update()
    {
        HandleJump();
        HandleMovement();
    }
    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftControl)) 
            _currentSpeed = speedRun;

        else
            _currentSpeed = speed;

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody2d.velocity = new Vector2(-_currentSpeed, rigidbody2d.velocity.y);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody2d.velocity = new Vector2(_currentSpeed, rigidbody2d.velocity.y);
        }

        if (rigidbody2d.velocity.x > 0)
        {
            rigidbody2d.velocity += friction;
        }

        else if (rigidbody2d.velocity.x < 0)
        {
            rigidbody2d.velocity -= friction;
        }
    }

    private void HandleJump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2d.velocity = Vector2.up * jumpForce;
        }
    }
}
