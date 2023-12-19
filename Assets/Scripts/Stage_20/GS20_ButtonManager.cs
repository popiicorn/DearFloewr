using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GS20_ButtonManager : MonoBehaviour
{
    [SerializeField] GS20_Button[] buttons;
    int[] answer = { 2, 0, 1, 3};
    [SerializeField] EventData[] OnClearEvent;
    [SerializeField] EventTrigger eventTrigger;
    private void Awake()
    {
        foreach (var button in buttons)
        {
            button.OnClickEvent += CheckClear;
        }
    }

    public void DebugLoggg(int num)
    {
        Debug.Log(num);
    }

    void CheckClear()
    {
        // buttons‚Ìindex‚ğanswer‚Æ”äŠr‚µ‚ÄA‘S‚Äˆê’v‚µ‚Ä‚¢‚½‚çClear
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].Index != answer[i])
            {
                return;
            }
        }
        foreach (var button in buttons)
        {
            button.GetComponent<EventTrigger>().enabled = false;
        }
        eventTrigger.enabled = false;
        // Clearˆ—
        StartCoroutine(Clear());
    }

    IEnumerator Clear()
    {
        foreach (var eventData in OnClearEvent)
        {
            yield return eventData.Play();
        }
    }
    

}
