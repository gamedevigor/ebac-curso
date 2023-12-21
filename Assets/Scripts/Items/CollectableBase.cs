using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem particlesSystem;
    public float timeToDestroy = .2f;

    [Header("Souds")]
    public AudioSource audioSource;

    private void Awake()
    {
        if (particlesSystem != null)
        {
            particlesSystem.transform.SetParent(null);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(compareTag)) 
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        OnCollect();
        Invoke("Destroy", timeToDestroy);
    }

    protected virtual void Destroy()
    {
        Destroy(gameObject);
    }

    protected virtual void OnCollect()
    {
        if (particlesSystem != null) { particlesSystem.Play(); }
        if (audioSource != null) { audioSource.Play(); }
    }
}
