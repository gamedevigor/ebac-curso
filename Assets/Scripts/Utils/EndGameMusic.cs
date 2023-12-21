using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EndGameMusic : MonoBehaviour
{
    public AudioMixerSnapshot snapshot1;
    public AudioMixerSnapshot snapshot2;
    public string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(playerTag))
        {
            snapshot2.TransitionTo(.1f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(playerTag))
        {
            snapshot1.TransitionTo(.1f);
        }
    }
}
