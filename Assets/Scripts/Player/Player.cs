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

    private float _currentSpeed;

    [Header("Jump Collision Check")]
    public Collider2D collider2d;
    public float distToGround;
    public float spaceToGround = .1f;
    public ParticleSystem jumpVFX;

    private void Awake()
    {
        healthBase.OnKill += OnPlayerKill;

        _currentPlayer = Instantiate(soPlayerSetup.player, transform);
        _currentPlayer.GetComponentInChildren<PlayerDestroyHelper>().player = this;
        _currentPlayer.GetComponentInChildren<GunBase>().playerSideReference = transform;

        if (collider2d != null )
        {
            distToGround = collider2d.bounds.extents.y;
        }
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
        isGrounded();
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
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rigidbody2d.velocity = Vector2.up * soPlayerSetup.jumpForce;
            

            _currentPlayer.SetBool(soPlayerSetup.boolJump, true);

            DOTween.Kill(rigidbody2d.transform);

            playJumpVFX();

            HandleJumpScale();
        }

        else
        {
            _currentPlayer.SetBool(soPlayerSetup.boolJump, false);
        }
    }

    private void HandleJumpScale()
    {
        if (transform != null)
        rigidbody2d.transform.DOScaleY(soPlayerSetup.soJumpScaleY.value, soPlayerSetup.soAnimationDuration.value).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
    }

    private bool isGrounded()
    {
        return Physics2D.Raycast(transform.position, -Vector2.up, distToGround + spaceToGround);
    }

    private void playJumpVFX()
    {
        jumpVFX.Play();
    }


    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
