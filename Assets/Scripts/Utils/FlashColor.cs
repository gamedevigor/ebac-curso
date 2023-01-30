using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashColor : MonoBehaviour
{
    public List<SpriteRenderer> renderers;
    public Color color = Color.red;
    public float duration = .2f;

    private Tween _currentTween;
 
    private void OnValidate()
    {
        renderers = new List<SpriteRenderer>();
        foreach (var child in transform.GetComponentsInChildren<SpriteRenderer>())
        {
           renderers.Add(child);
        }
    }

    public void Flash()
    {
        if (_currentTween != null)
        {
            _currentTween.Kill();
            renderers.ForEach(i => i.color = Color.white);
        }

        foreach (var s in renderers)
        {
            _currentTween = s.DOColor(color, duration).SetLoops(3, LoopType.Yoyo);
        }
    }
}
