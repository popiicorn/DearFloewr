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
        // 子オブジェクトのGS_31_Buttonを取得
        buttons = GetComponentsInChildren<GS_31_Button>();

        // ボタンが押された時に呼び出すイベントを設定
        foreach (var button in buttons)
        {
            button.OnClickAction += OnClickButton;
        }
    }

    // ボタンが押された時に呼び出される
    void OnClickButton(int clickedButtonIndex)
    {
        if (isClear)
        {
            return;
        }
        // 正解のボタンを押したかどうか判定
        bool isCorrect = correctButtonIndexs[currentButtonIndex] == clickedButtonIndex;
        buttons[clickedButtonIndex].PlayAnim(isCorrect);


        // 正解なら次のボタンへ
        if (isCorrect)
        {
            currentButtonIndex++;
            if (currentButtonIndex == correctButtonIndexs.Length)
            {
                isClear = true;
                miniGame.Clear();
            }
        }
        // 不正解なら最初から
        else
        {
            // 全てのボタンを不正解にする
            foreach (var button in buttons)
            {
                button.ResetButton();
            }
            currentButtonIndex = 0;
        }
    }
}
