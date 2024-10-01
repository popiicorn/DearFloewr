using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS28_BackLever : MonoBehaviour
{
    [SerializeField] List<EventData> eventDatas;

    public void Play()
    {   
        StopAllCoroutines();
        StartCoroutine(PlayAnim());
    }

    IEnumerator PlayAnim()
    {
        foreach(EventData eventData in eventDatas)
        {
            yield return eventData.Play();
        }
    }
}
