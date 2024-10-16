using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS28_MiniGame : MonoBehaviour
{
    GS28_3Switch[] switches;
    int[] correct = { 0, -1, 1, 1, -1, 0 };
    bool isClear;

    [SerializeField] EventData[] ClearEvents;

    private void Start()
    {
        // 子要素からGS28_3Switchを取得
        switches = GetComponentsInChildren<GS28_3Switch>();
    }

    private void Update()
    {
        if (isClear)
        {
            return;
        }
        ClearCheck();
    }

    void ClearCheck()
    {
        for (int i = 0; i < switches.Length; i++)
        {
            if (correct[i] != switches[i].SwitchIndex)
            {
                return;
            }
        }
        isClear = true;
        foreach (var btn in switches)
        {
            btn.SetClear();
        }
        StartCoroutine(PlayClearEvent());
    }

    IEnumerator PlayClearEvent()
    {
        foreach (var eventData in ClearEvents)
        {
            yield return eventData.Play();
        }
    }
}
