using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS26_KeyButtonManager : MonoBehaviour
{
    [SerializeField] GS26_KeyButton[] keyButtons;
    [SerializeField] int[] correctKeys;
    [SerializeField] EventData[] ClearEvents;
    bool canPush = false;
    bool isClear = false;
    int index = 0;
    private void Awake()
    {
        keyButtons = GetComponentsInChildren<GS26_KeyButton>(true);
        foreach (GS26_KeyButton keyButton in keyButtons)
        {
            keyButton.OnClickAction += SetAction;
        }
    }

    public void SetCanPush()
    {
        canPush = true;
    }

    public void SetAction(int keyNumber)
    {
        if (!canPush)
        {
            return;
        }
        if (isClear)
        {
            return;
        }
        if (correctKeys[index] == keyNumber)
        {
            keyButtons[index].PlayLineAnimator();
            index++;
        }
        else
        {
            foreach (var item in keyButtons)
            {
                item.PlayIdle();
            }
            keyButtons[keyNumber].PlayPush();
            index = 0;
        }

        if (index == correctKeys.Length)
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
