using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS27_Capsule : MonoBehaviour
{
    [SerializeField]
    EventData[] eventDatas;
    public static GS27_Capsule Instance { get; private set; }
    int count = 0;
    void Awake()
    {
        count = 0;
        Instance = this;
    }

   public void OnFlower()
    {
        count++;

        if (count == 8)
        {
            StartCoroutine(ClearEvent());
        }
    }

    IEnumerator ClearEvent()
    {
        foreach (var eventData in eventDatas)
        {
            yield return eventData.Play();
        }
    }
}
