using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class GS5_Shadow : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        Color color = spriteRenderer.color;
        color.a = 0;
        spriteRenderer.color = color;
        spriteRenderer.DOFade(1, Stage05Params.Instance.fadeDurationOfShadow);
    }

    public void Show(bool isActive)
    {
        if (isActive)
        {
            gameObject.SetActive(true);
        }
        else
        {
            spriteRenderer.DOFade(0, Stage05Params.Instance.fadeDurationOfShadow);
        }
    }
}
