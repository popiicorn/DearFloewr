using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS24_DoorPartsManager : MonoBehaviour
{
    [SerializeField] EventData[] OnClearEvent;

    int clearCount = 0;
    public void CheckDoorPartsGimmick()
    {
        clearCount++;
        if (clearCount == 2)
        {
            StartCoroutine(PlayClearEvent());
        }
    }



    IEnumerator PlayClearEvent()
    {
        foreach (var eventData in OnClearEvent)
        {
            yield return eventData.Play();
        }
    }
}
