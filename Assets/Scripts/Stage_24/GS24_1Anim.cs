using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS24_1Anim : MonoBehaviour
{
    [SerializeField] EventData[] eventDatas;
    public void OnAnimEnd()
    {
        StartCoroutine(Play());
    }

    IEnumerator Play()
    {
        foreach (var eventData in eventDatas)
        {
            yield return eventData.Play();
        }
    }
}
