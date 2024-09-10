using Steamworks;
using UnityEngine;

public class SteamAchievementManager : MonoBehaviour
{
    public static SteamAchievementManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void UnlockAchievement(string achievementName)
    {
        if (SteamManager.Initialized)
        {
            if (SteamUserStats.RequestCurrentStats())
            {
                // ユーザーの現在のデータと実績を非同期に要求後（必須）
                // statsを更新
                SteamUserStats.SetAchievement(achievementName);
                Debug.Log("Unlock Achievement: " + achievementName);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && Input.GetKey(KeyCode.LeftShift))
        {
            SteamUserStats.ResetAllStats(true);
            SteamUserStats.RequestCurrentStats();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            UnlockAchievement("ACHIEVEMENT_12");
        }
    }
}
