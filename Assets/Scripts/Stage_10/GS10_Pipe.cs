using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS10_Pipe : MonoBehaviour
{
    [SerializeField] EventData[] eventDatas;

    public void AnimComp()
    {
        StartCoroutine(AnimCor());
    }

    IEnumerator AnimCor()
    {
        foreach (var eventData in eventDatas)
        {
            yield return eventData.Play();
        }
    }
}
