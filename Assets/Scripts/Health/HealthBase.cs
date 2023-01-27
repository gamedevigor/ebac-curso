using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    [Header("Life Setup")]
    public int startLife = 10;
    public bool destroyOnKill = false;
    public float delayToDestroy = 0f;

    [Header("Damage Animation")]
    public float damageIndicationScale = 0.4f;
    public float animationDuration = .5f;
    public Ease ease = Ease.OutBack;

    private int _currentLife;
    private bool _isAlive = true;

    private void Awake()
    {
        Init();
    }

    private void Init()
    { 
        _isAlive = true;
    }

    public void Damage(int damage)
    {
        if (_isAlive == false) return;

        _currentLife -= damage;

        gameObject.transform.DOScaleY(-damageIndicationScale, animationDuration).SetLoops(3, LoopType.Yoyo).SetEase(ease);

        if (_currentLife<= 0)
        {
            Kill();
        }

    }

    private void Kill()
    {
        _isAlive = false;
        if (destroyOnKill)
        {
            Destroy(gameObject, delayToDestroy);
        }
    }
}
