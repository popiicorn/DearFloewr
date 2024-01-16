using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS28_3Switch : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GS28_Button[] buttons;
    [SerializeField] Transform switchObj;
    public UnityAction OnMoved;
    bool isClear;
    public int SwitchIndex
    {
        get
        {
            // switchObjのポジションが0.5なら1,0なら0,-0.5なら-1を返す
            if (switchObj.localPosition.y > 0.4f)
            {
                return 1;
            }
            else if (switchObj.localPosition.y < -0.4f)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }


    private void Start()
    {
        foreach (GS28_Button button in buttons)
        {
            button.OnButtonPressed += OnButtonPressed;
        }
    }

    void OnButtonPressed(GS28_Button.ButtonType buttonType)
    {
        if (isClear)
        {
            return;
        }
        // アニメーション中は何もしない
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Up") ||
                       animator.GetCurrentAnimatorStateInfo(0).IsName("Down"))
        {
            return;
        }
        Debug.Log("OnButtonPressed: " + buttonType);
        switch (buttonType)
        {
            case GS28_Button.ButtonType.Top:
                if (SwitchIndex != 1 )
                {
                    animator.SetTrigger("Up");
                    animator.ResetTrigger("Down");
                }
                break;
            case GS28_Button.ButtonType.Center:
                if (SwitchIndex == -1)
                {
                    // 中央に上げる
                    animator.SetTrigger("Up");
                    animator.ResetTrigger("Down");
                }
                else if (SwitchIndex == 1)
                {
                    // 中央に下げる
                    animator.SetTrigger("Down");
                    animator.ResetTrigger("Up");
                }

                // animator.SetTrigger("Center");
                break;
            case GS28_Button.ButtonType.Bottom:

                if (SwitchIndex != -1)
                {
                    // Bottomに下げる
                    animator.SetTrigger("Down");
                    animator.ResetTrigger("Up");
                }
                break;
        }
        OnMoved?.Invoke();
    }

    public void SetClear()
    {
          isClear = true;
    }

}
