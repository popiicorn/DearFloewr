using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamAchievementSetter : MonoBehaviour
{
    [SerializeField] string achievementName;
    void Start()
    {
        GameManager.Instance.OnClearCkeckSteamAchievement = Hoge;
    }

    private void Hoge()
    {
        SteamAchievementManager.Instance.UnlockAchievement(achievementName);
    }
}
