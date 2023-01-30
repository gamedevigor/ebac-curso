using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;

    public Animator animator;
    public string attackTrigger = "Attack";
    public string deathTrigger = "Death";

    public HealthBase healthBase;

    private void Awake()
    {
        healthBase.OnKill += OnEnemyKill;
    }

    private void OnEnemyKill()
    {
        healthBase.OnKill -= OnEnemyKill;
        playDeath();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var health = collision.gameObject.GetComponent<HealthBase>();

        if (health != null)
        {
            health.Damage(damage);
            playAttack();
        }
    }

    private void playAttack()
    {
        animator.SetTrigger(attackTrigger);
    }

    private void playDeath()
    {
        animator.SetTrigger(deathTrigger);
    }

    public void Damage(int amount)
    {
        healthBase.Damage(amount);
    }
}
