using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS14_Panel : MonoBehaviour
{
    // �N���b�N�����Ƃ��Ƀp�[�c����]������
    public void OnClick()
    {
        Debug.Log("�N���b�N������");
        // �p�[�c����]������
        GS14_MiniGameManager.Instance.CurrentPart.Rotate();
    }
}
