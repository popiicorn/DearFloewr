using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
public class GS20_FlowerGetObj : MonoBehaviour
{
    bool isClicked = false;
    // �N���b�N����ƍ��ɓ���
    // ��x�N���b�N�����ƁA�N���b�N�ł��Ȃ��Ȃ�
    public void OnClick()
    {
        if (isClicked) return;
        isClicked = true;
        // ���Ɉړ��F�ŏ��ƍŌオ�x���Ȃ�
        transform.DOMoveX(1.8f, 2).SetEase(Ease.Linear);
        GetComponent<BoxCollider2D>().enabled = false;
        //transform.DOMoveX(1.8f, 3).SetEase(Ease.InOutQuint);
    }
}
