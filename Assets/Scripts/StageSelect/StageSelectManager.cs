using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class StageSelectManager : MonoBehaviour
{
    // セーブデータを見てステージのボーナスを取得しているかどうかを判定する
    [SerializeField] ButtonStage[] buttonStages;

    private void Start()
    {
        buttonStages = GetComponentsInChildren<ButtonStage>(true);
        for (int i = 0; i < buttonStages.Length; i++)
        {
            buttonStages[i].SetStageData(SaveManager.Instance.saveData.stages[i]);
            buttonStages[i].OnClickButton = OnClickStageButton;
        }

        if (SteamManager.Initialized)
        {
            Debug.Log("SteamManager.Initialized");
            if (SteamUserStats.RequestCurrentStats())
            {
                Debug.Log("SteamUserStats.RequestCurrentStats");
                // ユーザーの現在のデータと実績を非同期に要求後（必須）

                // statsを更新
                SteamUserStats.SetAchievement("ACHIEVEMENT_Test");
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
    }

    public void OnClickStageButton(int number)
    {

    }

    public void OnBackButton()
    {
        GameManager.Instance.ToTitle();
        BGMManager.Instance.OffAisac();
    }
}
