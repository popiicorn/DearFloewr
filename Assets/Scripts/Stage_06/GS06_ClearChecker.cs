using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS06_ClearChecker : MonoBehaviour
{
    [SerializeField] int[] correctMarkIndex;
    // 絵柄があっているか確かめる
    [SerializeField] GS06_Monitor[] gS06_Monitors;
    public UnityEvent OnClearEvent;

    private void Awake()
    {
        foreach (var monitor in gS06_Monitors)
        {
            monitor.OnPushed = CheckCorrect;
        }
    }
    public void CheckCorrect()
    {
        for (int i = 0; i < gS06_Monitors.Length; i++)
        {
            if (correctMarkIndex[i] != gS06_Monitors[i].Index)
            {
                return;
            }
        }
        // クリア
        OnClearEvent?.Invoke();
    }
}
