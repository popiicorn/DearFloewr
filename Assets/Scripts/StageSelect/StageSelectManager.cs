using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    public void OnClickStageButton(int number)
    {

    }
}
