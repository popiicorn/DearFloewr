using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GS5_DummyStone : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FadeOut()
    {
        spriteRenderer.DOFade(0, Stage05Params.Instance.fadeDurationOfShadow).OnComplete(() => gameObject.SetActive(false));
    }
}
