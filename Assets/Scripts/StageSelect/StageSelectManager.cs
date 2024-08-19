using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    public void OnClickStageButton(int number)
    {

    }
}
