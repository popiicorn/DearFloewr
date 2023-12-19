using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS21_WindowsManager : MonoBehaviour
{
    GS21_Window[] windows;
    [SerializeField] UnityEvent OnClearEvent;

    void Start()
    {
        windows = GetComponentsInChildren<GS21_Window>();
        foreach (var window in windows)
        {
            window.OnClickEvent += CheckClear;
        }
    }

    void CheckClear()
    {
        foreach (var window in windows)
        {
            if (window.gameObject.activeSelf)
            {
                return;
            }
        }
        // Clearèàóù
        OnClearEvent?.Invoke();
    }
}
