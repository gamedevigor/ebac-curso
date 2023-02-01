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

    [Header("Setup")]
    public SOPlayerSetup soPlayerSetup;
    public Animator _currentPlayer;

    private bool falling;
    private float _currentSpeed;


    private void Awake()
    {
        healthBase.OnKill += OnPlayerKill;

        _currentPlayer = Instantiate(soPlayerSetup.player, transform);
    }

    private void OnPlayerKill()
    {
        if (healthBase != null) healthBase.OnKill -= OnPlayerKill;
        _currentPlayer.SetTrigger(soPlayerSetup.triggerDeath);
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
            _currentSpeed = soPlayerSetup.speedRun;
            _currentPlayer.speed = soPlayerSetup.runningAnimationSpeed;
        }

        else
        {
            _currentSpeed = soPlayerSetup.speed;
            _currentPlayer.speed = soPlayerSetup.regularAnimationSpeed;
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody2d.velocity = new Vector2(-_currentSpeed, rigidbody2d.velocity.y);

            if (rigidbody2d.transform.localScale.x != -1)
            {
                rigidbody2d.transform.DOScaleX(-1, soPlayerSetup.swipeDuration);
            }

            _currentPlayer.SetBool(soPlayerSetup.boolRun, true);

        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody2d.velocity = new Vector2(_currentSpeed, rigidbody2d.velocity.y);
            
            if (rigidbody2d.transform.localScale.x != 1)
            {
                rigidbody2d.transform.DOScaleX(1, soPlayerSetup.swipeDuration);
            }

            _currentPlayer.SetBool(soPlayerSetup.boolRun, true);
        }

        else
        {
            _currentPlayer.SetBool(soPlayerSetup.boolRun, false);
        }

        if (rigidbody2d.velocity.x > 0)
        {
            rigidbody2d.velocity += soPlayerSetup.friction;
        }

        else if (rigidbody2d.velocity.x < 0)
        {
            rigidbody2d.velocity -= soPlayerSetup.friction;
        }
    }

    private void HandleJump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2d.velocity = Vector2.up * soPlayerSetup.jumpForce;
            

            _currentPlayer.SetBool(soPlayerSetup.boolJump, true);

            DOTween.Kill(rigidbody2d.transform);

            HandleJumpScale();
        }

        else
        {
            _currentPlayer.SetBool(soPlayerSetup.boolJump, false);
        }
    }

    private void HandleJumpScale()
    {
        rigidbody2d.transform.DOScaleY(soPlayerSetup.soJumpScaleY.value, soPlayerSetup.soAnimationDuration.value).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
        falling = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (falling == false)
        {
         
        }

        else if (falling == true)
        {
            rigidbody2d.transform.DOScaleY(-soPlayerSetup.soFallScale.value, soPlayerSetup.soAnimationDuration.value).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
            falling = false;
        }
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
