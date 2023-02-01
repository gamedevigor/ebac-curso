using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOPlayerSetup : ScriptableObject
{
    public Vector2 friction = new Vector2(-.1f, 0);

    [Header("Speed Setup")]
    public float speed;
    public float speedRun;
    public float jumpForce = 5;

    [Header("Animation Setup")]
    public Ease ease = Ease.OutBack;
    public SOFloat soJumpScaleY;
    public SOFloat soFallScale;
    public SOFloat soAnimationDuration;

    [Header("Animator")]
    public string boolRun = "Run";
    public string boolJump = "Jump";
    public string triggerDeath = "Death";
    public float swipeDuration = .2f;
    public float runningAnimationSpeed = 1.5f;
    public float regularAnimationSpeed = 1;
}
