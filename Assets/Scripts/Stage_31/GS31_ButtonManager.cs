using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS31_ButtonManager : MonoBehaviour
{
    GS_31_Button[] buttons;

    int currentButtonIndex = 0;

    [SerializeField] int[] correctButtonIndexs;
    bool isClear = false;
    [SerializeField] GS_31_MiniGame miniGame;

    void Start()
    {
        // �q�I�u�W�F�N�g��GS_31_Button���擾
        buttons = GetComponentsInChildren<GS_31_Button>();

        // �{�^���������ꂽ���ɌĂяo���C�x���g��ݒ�
        foreach (var button in buttons)
        {
            button.OnClickAction += OnClickButton;
        }
    }

    // �{�^���������ꂽ���ɌĂяo�����
    void OnClickButton(int clickedButtonIndex)
    {
        if (isClear)
        {
            return;
        }
        // �����̃{�^�������������ǂ�������
        bool isCorrect = correctButtonIndexs[currentButtonIndex] == clickedButtonIndex;
        buttons[clickedButtonIndex].PlayAnim(isCorrect);


        // �����Ȃ玟�̃{�^����
        if (isCorrect)
        {
            currentButtonIndex++;
            if (currentButtonIndex == correctButtonIndexs.Length)
            {
                isClear = true;
                miniGame.Clear();
            }
        }
        // �s�����Ȃ�ŏ�����
        else
        {
            // �S�Ẵ{�^����s�����ɂ���
            foreach (var button in buttons)
            {
                button.ResetButton();
            }
            currentButtonIndex = 0;
        }
    }
}
