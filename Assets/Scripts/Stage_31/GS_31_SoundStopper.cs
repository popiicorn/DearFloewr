using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS_31_SoundStopper : MonoBehaviour
{
    [SerializeField] List<EventData> eventDatas;
    public void StopSound()
    {
        // CriManager.instance.StopObjSE();
        StartCoroutine(PlayEvent());
    }

    IEnumerator PlayEvent()
    {
        foreach (var eventData in eventDatas)
        {
            yield return eventData.Play();
        }
    }
}
