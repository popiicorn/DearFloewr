using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class FadeSpriteRenderer : MonoBehaviour
{
    public UnityEvent OnFadeEndEvent;
    [SerializeField] float fadeDuration;
    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DoFade()
    {
        spriteRenderer.DOFade(1, fadeDuration).OnComplete(() => OnFadeEndEvent?.Invoke());
    }
}
