using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Animator animator;
    public KeyCode startRadarAnimation = KeyCode.A;
    public KeyCode endRadarAnimation = KeyCode.S;
    public string triggerToPlay = "DetectPlayer";

    private void OnValidate()
    {
        if (animator == null) animator = GetComponent<Animator>(); 
    }
    void Update()
    {
        if (Input.GetKeyDown(startRadarAnimation))
        {
            animator.SetBool(triggerToPlay, true);
        }

        else if (Input.GetKeyDown(endRadarAnimation))
        {
            animator.SetBool(triggerToPlay, false);
        }
    }
}
