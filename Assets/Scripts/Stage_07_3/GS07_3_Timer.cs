using Com.LuisPedroFonseca.ProCamera2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS07_3_Timer : MonoBehaviour
{
    [SerializeField] Character character;
    [SerializeField] UnityEvent ClearEvent;
    [SerializeField] ProCamera2D proCamera2D;
    IEnumerator Start()
    {

        // character‚ÌxÀ•W‚ª50‚ğ‚±‚¦‚é‚Ü‚Å‘Ò‹@
        while (character.transform.position.x < 60)
        {
            yield return null;
        }
        ClearEvent?.Invoke();
        Debug.Log("Clear");
        proCamera2D.enabled = false;
    }
}
