using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class FadeSpriteRenderer : MonoBehaviour
{
    public UnityEvent OnFadeEndEvent;
    SpriteRenderer spriteRenderer;
    public float fadeDurationOfDarkSky;
    [SerializeField] int endValue;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DoFade()
    {
        spriteRenderer.DOFade(endValue, fadeDurationOfDarkSky).OnComplete(() => OnFadeEndEvent?.Invoke());
    }
}
