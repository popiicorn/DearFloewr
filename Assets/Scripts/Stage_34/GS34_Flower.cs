using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS34_Flower : MonoBehaviour
{
    // �Ԃ��炭�Ƃ��ɁA�A�����ėׂ̉Ԃ��ڂ݂ɂȂ�:�ߏ����p��ŉ��ƌ����� -> neighbor
    [SerializeField] GS34_Flower[] neighborFlowers;
    GS34_Bud selfBut;
    // �Ԃ��炢�Ă��邩�ǂ���
    bool isBloomed = false;

    public bool IsBloomed { get => isBloomed; }

    public void SetSelfBut(GS34_Bud bud)
    {
        selfBut = bud;
    }


    // �Ԃ��T�N
    public void Bloom(bool isPair = false)
    {
        if (isBloomed)
        {
            return;
        }
        selfBut.gameObject.SetActive(false);
        isBloomed = true;
        // �Ԃ�\������
        gameObject.SetActive(true);
        if (isPair)
        {
            return;
        }
        // �ׂ̉Ԃ��ڂ݂ɂ���
        foreach (var flower in neighborFlowers)
        {
            flower.Bud();
        }
    }

    // �Ԃ��ڂ�
    public void Bud()
    {
        if (!isBloomed)
        {
            return;
        }
        isBloomed = false;
        // �Ԃ��\���ɂ���
        gameObject.SetActive(false);
        selfBut.ShowBud();
    }
}
