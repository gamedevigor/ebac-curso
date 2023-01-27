using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public Vector2 friction = new Vector2(-.1f, 0);

    [Header("Speed Setup")]
    public float speed;
    public float speedRun;
    public float jumpForce = 5;

    [Header("Animation Setup")]
    public float jumpScaleY = 1.3f;
    public float jumpScaleX = .5f;
    public float fallScaleY = 0.9f;
    public float fallScaleX = 1.2f;
    public float animationDuration = .3f;
    public Ease ease = Ease.OutBack;

    private bool falling;
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
            rigidbody2d.transform.localScale = Vector2.one;

            DOTween.Kill(rigidbody2d.transform);

            HandleJumpScale();
        }
    }

    private void HandleJumpScale()
    {
        rigidbody2d.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        rigidbody2d.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        falling = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (falling == false)
        {
         
        }

        else if (falling == true)
        {
            rigidbody2d.transform.DOScaleY(-fallScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
            rigidbody2d.transform.DOScaleX(-fallScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
            falling = false;
        }
    }
}
