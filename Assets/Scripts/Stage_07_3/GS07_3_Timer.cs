using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS07_3_Timer : MonoBehaviour
{
    [SerializeField] UnityEvent ClearEvent;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(Stage07_3Params.Instance.Timer);
        ClearEvent?.Invoke();
    }
}
