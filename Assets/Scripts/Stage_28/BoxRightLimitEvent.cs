using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRightLimitEvent : MonoBehaviour
{
    [SerializeField] Gimmick gimmick;
    [SerializeField] List<EventData> eventDatas;
    // Start is called before the first frame update
    void Start()
    {
        gimmick.OnLimit += OnLimit;
    }

    void OnLimit()
    {
        StopAllCoroutines();
        StartCoroutine(EventCoroutine());
    }

    IEnumerator EventCoroutine()
    {
        foreach (var eventData in eventDatas)
        {
            yield return eventData.Play();
        }
    }
}
