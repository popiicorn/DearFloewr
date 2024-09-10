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
                // ���[�U�[�̌��݂̃f�[�^�Ǝ��т�񓯊��ɗv����i�K�{�j
                // stats���X�V
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
