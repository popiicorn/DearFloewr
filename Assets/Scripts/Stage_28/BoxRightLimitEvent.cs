using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class BoxRightLimitEvent : MonoBehaviour
{
    [SerializeField] Gimmick gimmick;
    [SerializeField] List<EventData> eventDatas;
    [SerializeField] bool canSound = false;
    [SerializeField] UnityEvent onLeave;
    // Start is called before the first frame update
    void Start()
    {
        // gimmick.OnLimit += OnLimit;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<GS28_Box>() || collision.GetComponent<GS29_Box>())
        {
            if (!canSound)
            {
                canSound = true;
                return;
            }
            OnLimit();
            Debug.Log("OnTriggerEnter2D" + collision.name);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<GS29_Box>())
        {
            onLeave?.Invoke();
        }
    }
}
