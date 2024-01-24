using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS_31_Button : MonoBehaviour
{
    [SerializeField] int buttonIndex;
    // animatorを取得
    Animator animator;

    // クリックされた時に呼び出すイベント
    public UnityAction<int> OnClickAction;
    void Start()
    {
        // animatorを取得
        animator = GetComponent<Animator>();
    }

    // ボタンを押した時にManagerに通知して正解かどうか判断する
    public void OnClick()
    {
        OnClickAction?.Invoke(buttonIndex);
    }

    public void PlayAnim(bool isCorrect)
    {
        // ボタンを押した時に、正解ならPush_OKアニメーション
        // 不正解ならPush_Onlyアニメーション
        if (isCorrect)
        {
            animator.Play("Push_OK");
        }
        else
        {
            animator.Play("Push_Only");
        }
    }

    public void ResetButton()
    {
        animator.Play("Idle");
    }
}
