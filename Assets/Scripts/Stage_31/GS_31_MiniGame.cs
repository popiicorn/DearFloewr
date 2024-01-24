using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS_31_MiniGame : MonoBehaviour
{
    [SerializeField] EventData[] eventDatas;
    public void Clear()
    {
        StartCoroutine(EventPlay());
    }

    IEnumerator EventPlay()
    {
        foreach (var eventData in eventDatas)
        {
            yield return eventData.Play();
        }
    }

}
