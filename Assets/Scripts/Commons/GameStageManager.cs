using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStageManager : MonoBehaviour
{
    int stageIndex = 0;
    const int stageCount = 7;

    public static GameStageManager Instance { get; private set; }
    void Awake()
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

    public string GetNextStageName()
    {
        stageIndex++;
        if (stageCount < stageIndex)
        {
            stageIndex = 0;
            return "Title_Demo";
        }
        return "Stage_" + stageIndex.ToString("D2");
    }

    // �V�[���ԃX�e�[�W�ł̑J��
} 