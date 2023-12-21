using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.VFX;

public class AudioTransition : MonoBehaviour
{
    public AudioMixerSnapshot snapshot;
    public float transitionTime = .1f;

    public void makeTransition()
    {
        snapshot.TransitionTo(transitionTime);
    }

}
