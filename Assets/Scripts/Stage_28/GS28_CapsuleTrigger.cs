using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS28_CapsuleTrigger : MonoBehaviour
{
    [SerializeField] EventData[] ClearEvents;
    // 2D‚ÅCharacter‚ªG‚ê‚é‚Æcapsule‚ğ•\¦
    bool isClear;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isClear)
        {
            return;
        }
        if (collision.GetComponent<Character>())
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
