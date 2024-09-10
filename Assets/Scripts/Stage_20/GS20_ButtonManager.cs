using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GS20_ButtonManager : MonoBehaviour
{
    [SerializeField] GS20_Button[] buttons;
    [SerializeField] int[] answer = { 2, 0, 1, 3};
    [SerializeField] EventData[] OnClearEvent;
    [SerializeField] EventTrigger eventTrigger;
    [SerializeField] GS20_Video video;
    private void Awake()
    {
        foreach (var button in buttons)
        {
            button.OnClickEvent += CheckClear;
        }
    }

    private void Start()
    {
        GameManager.Instance.OnClearCkeckSteamAchievement = () =>
        {
            CheckAchievement();
        };
    }

    void CheckAchievement()
    {
        Debug.Log("wasPlayed" + video.wasPlayed);
        if (!video.wasPlayed)
        {
            SteamAchievementManager.Instance.UnlockAchievement("ACHIEVEMENT_7");
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
