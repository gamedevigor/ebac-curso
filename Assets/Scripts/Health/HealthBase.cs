using System;
using DG.Tweening;
using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    [Header("Life Setup")]
    public int startLife = 10;
    public bool destroyOnKill = false;
    public float delayToDestroy = .4f;

    public FlashColor flashColor;
    private int _currentLife;
    private bool _isAlive = true;

    public Action OnKill;

    private void Awake()
    {
        Init();
        
        if (flashColor == null)
        {
            flashColor.GetComponent<FlashColor>();
        }
    }

    private void Init()
    { 
        _isAlive = true;
    }

    public void Damage(int damage)
    {
        if (_isAlive == false) return;

        _currentLife -= damage;

        if (_currentLife <= 0)
        {
            Kill();
        }

        if (flashColor != null) 
        {
            flashColor.Flash();
        }

    }

    private void Kill()
    {
        _isAlive = false;
        if (destroyOnKill)
        {
            Destroy(gameObject, delayToDestroy);
        }

        OnKill?.Invoke();
    }
}
