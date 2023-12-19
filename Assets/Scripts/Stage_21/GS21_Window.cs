using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS21_Window : MonoBehaviour
{
    public UnityAction OnClickEvent;
    private void OnDisable()
    {
        OnClickEvent?.Invoke();
    }
}
