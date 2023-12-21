using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandomPlayAudioClips : MonoBehaviour
{
    public List<AudioClip> audioClipsList;

    public List<AudioSource> audioSourcesLsit;

    private int _index = 0;

    public void PlayRandom()
    {
        if (_index >= audioSourcesLsit.Count) _index = 0;

        var audioSource = audioSourcesLsit[_index];

        audioSource.clip = audioClipsList[Random.Range(0, audioClipsList.Count)];
        audioSource.Play();

        _index++;
    }
}
