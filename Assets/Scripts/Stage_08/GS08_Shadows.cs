using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GS08_Shadows : MonoBehaviour
{
    [SerializeField] EventData[] eventDatas;
    // Start is called before the first frame update
    public void Fade()
    {
        SpriteRenderer[] spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        ParticleSystem[] particleSystems = GetComponentsInChildren<ParticleSystem>();
        foreach (var spriteRenderer in spriteRenderers)
        {
            spriteRenderer.DOFade(0, 1).OnComplete(() => StartCoroutine(Complete()));
        }
        foreach (var particleSystem in particleSystems)
        {
            particleSystem.gameObject.SetActive(false);
        }
    }

    IEnumerator Complete()
    {
        foreach (var eventData in eventDatas)
        {
            yield return eventData.Play();
        }
    }


}
