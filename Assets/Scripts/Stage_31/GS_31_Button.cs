using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS_31_Button : MonoBehaviour
{
    [SerializeField] int buttonIndex;
    // animator���擾
    Animator animator;

    // �N���b�N���ꂽ���ɌĂяo���C�x���g
    public UnityAction<int> OnClickAction;
    void Start()
    {
        // animator���擾
        animator = GetComponent<Animator>();
    }

    // �{�^��������������Manager�ɒʒm���Đ������ǂ������f����
    public void OnClick()
    {
        OnClickAction?.Invoke(buttonIndex);
    }

    public void PlayAnim(bool isCorrect)
    {
        // �{�^�������������ɁA�����Ȃ�Push_OK�A�j���[�V����
        // �s�����Ȃ�Push_Only�A�j���[�V����
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
