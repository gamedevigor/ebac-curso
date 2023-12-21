using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioVolumeController : MonoBehaviour
{
    public AudioMixer group;
    public string floatParam = "MyExposedParam";

    public void changeVolume(float f)
    {
        group.SetFloat(floatParam, f);
    }
}
