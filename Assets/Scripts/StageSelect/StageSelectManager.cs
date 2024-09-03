using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class StageSelectManager : MonoBehaviour
{
    // �Z�[�u�f�[�^�����ăX�e�[�W�̃{�[�i�X���擾���Ă��邩�ǂ����𔻒肷��
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
                // ���[�U�[�̌��݂̃f�[�^�Ǝ��т�񓯊��ɗv����i�K�{�j

                // stats���X�V
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
