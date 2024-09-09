using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightStoneManager : MonoBehaviour
{
    public UnityEvent OnClearEvent;
    [SerializeField] LightStone[] lightStones;
    int[] correctID = new int[] {1,3,0,2};
    public static LightStoneManager Instance { get; private set; }
    int index;
    // ˆê“x‚àŠÔˆá‚¦‚¸‚ÉƒNƒŠƒA‚µ‚½‚©‚Ç‚¤‚©
    bool isNoMissClear = true;

    private void Awake()
    {
        Instance = this;
    }

    public bool IsCorrect(int id)
    {
        if (correctID[index] == id)
        {
            index++;
            if (index == correctID.Length)
            {
                OnClearEvent?.Invoke();
                if (isNoMissClear)
                {
                    SteamAchievementManager.Instance.UnlockAchievement("ACHIEVEMENT_3");
                }
            }
            return true;
        }
        AllLightOff();
        isNoMissClear = false;
        return false;
    }

    void AllLightOff()
    {
        foreach (var lightStone in lightStones)
        {
            lightStone.LightOff();
        }
        index = 0;
    }
}
