using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using DG.Tweening;
using JetBrains.Annotations;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public HealthBase healthBase;
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

    [Header("Animator")]
    public string boolRun = "Run";
    public string boolJump = "Jump";
    public string triggerDeath = "Death";
    public Animator animator;
    public float swipeDuration = .2f;
    public float runningAnimationSpeed = 1.5f;
    public float regularAnimationSpeed = 1;
    

    private bool falling;
    private float _currentSpeed;


    private void Awake()
    {
        healthBase.OnKill += OnPlayerKill;
    }

    private void OnPlayerKill()
    {
        if (healthBase != null) healthBase.OnKill -= OnPlayerKill;
        animator.SetTrigger(triggerDeath);
    }

    private void Update()
    {
        HandleJump();
        HandleMovement();
    }
    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        { 
            _currentSpeed = speedRun;
            animator.speed = runningAnimationSpeed;
        }

        else
        {
            _currentSpeed = speed;
            animator.speed = regularAnimationSpeed;
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody2d.velocity = new Vector2(-_currentSpeed, rigidbody2d.velocity.y);

            if (rigidbody2d.transform.localScale.x != -1)
            {
                rigidbody2d.transform.DOScaleX(-1, swipeDuration);
            }

            animator.SetBool(boolRun, true);

        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody2d.velocity = new Vector2(_currentSpeed, rigidbody2d.velocity.y);
            
            if (rigidbody2d.transform.localScale.x != 1)
            {
                rigidbody2d.transform.DOScaleX(1, swipeDuration);
            }

            animator.SetBool(boolRun, true);
        }

        else
        {
            animator.SetBool(boolRun, false);
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

            animator.SetBool(boolJump, true);

            DOTween.Kill(rigidbody2d.transform);

            HandleJumpScale();
        }

        else
        {
            animator.SetBool(boolJump, false);
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

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
