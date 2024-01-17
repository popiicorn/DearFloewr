using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GS28_BoxSwitch : MonoBehaviour
{
    [SerializeField] EventData[] ClearEvents;
    [SerializeField] EventData[] SetEvents;
    bool isBoxSet = false;
    bool isTreeHole = false;
    bool isClear = false;
    // –Ø‚ÌŒŠ‚ªŠJ‚¢‚Ä‚¢‚½‚ç
    private void Update()
    {
        if (isClear) 
        {
            return;
        }
        if (!isBoxSet)
        {
            return;
        }
        if (!isTreeHole)
        {
            return;
        }
        isClear = true;
        StartCoroutine(PlayClearEvents());

    }

    // ‚à‚µRock‚ª‚Ô‚Â‚©‚Á‚½‚ç
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IRockable rock = collision.GetComponentInParent<IRockable>();
        if (rock != null)
        {
            isBoxSet = true;
            collision.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
            collision.GetComponentInParent<IRockable>().SetLock(true);
            StartCoroutine(PlaySetEvent());
        }
    }

    IEnumerator PlaySetEvent()
    {
          foreach(var eventData in SetEvents)
        {
            yield return eventData.Play();
        }
    }

    IEnumerator PlayClearEvents()
    {
        foreach (var eventData in ClearEvents)
        {
            yield return eventData.Play();
        }
    }

    public void SetTreeHole()
    {
        isTreeHole = true;
    }
}
