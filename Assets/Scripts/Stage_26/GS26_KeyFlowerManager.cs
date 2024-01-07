using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS26_KeyFlowerManager : MonoBehaviour
{
    [SerializeField] EventData[] ClearEvents;

    bool isClear = false;
    int count = 0;


    public void SetClear()
    {
        if (isClear)
        {
            return;
        }
        count++;
        if (count == 3)
        {
            isClear = true;
            StartCoroutine(PlayClearEvent());
        }

    }

    IEnumerator PlayClearEvent()
    {
        foreach (var eventData in ClearEvents)
        {
            yield return eventData.Play();
        }
    }
}
