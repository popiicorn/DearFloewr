using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class FadeSpriteRenderer : MonoBehaviour
{
    public UnityEvent OnFadeEndEvent;
    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DoFade()
    {
        spriteRenderer.DOFade(1, Stage04Params.Instance.fadeDurationOfDarkSky).OnComplete(() => OnFadeEndEvent?.Invoke());
    }
}
