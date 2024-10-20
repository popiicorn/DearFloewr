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

        // characterのx座標が50をこえるまで待機
        while (character.transform.position.x < 60)
        {
            yield return null;
        }
        ClearEvent?.Invoke();
        Debug.Log("Clear");
        proCamera2D.enabled = false;
    }
}
