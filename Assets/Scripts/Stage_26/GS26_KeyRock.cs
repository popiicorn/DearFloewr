using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS26_KeyRock : MonoBehaviour
{
    int count = 0;
    [SerializeField] EventData[] ClearEvents;

    public void KeyDust()
    {
        count++;
        if (count >= 2)
        {
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
