using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GS08_StageParts : MonoBehaviour
{
    [SerializeField] DOTweenAnimation[] dOTweenAnimations;
    public void Play()
    {
        foreach (var item in dOTweenAnimations)
        {
            item.DOPlay();
        }
    }

    public void Stop()
    {
        foreach (var item in dOTweenAnimations)
        {
            item.DOPause();
        }
    }
}
