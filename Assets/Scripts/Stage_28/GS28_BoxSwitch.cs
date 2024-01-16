using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS28_BoxSwitch : MonoBehaviour
{
    [SerializeField] EventData[] ClearEvents;
    // ‚à‚µRock‚ª‚Ô‚Â‚©‚Á‚½‚ç
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IRockable rock = collision.GetComponentInParent<IRockable>();
        if (rock != null)
        {
            collision.GetComponentInParent<IRockable>().SetLock(true);
            StartCoroutine(PlayClearEvents());
        }
    }

    IEnumerator PlayClearEvents()
    {
        foreach (var eventData in ClearEvents)
        {
            yield return eventData.Play();
        }
    }
}
