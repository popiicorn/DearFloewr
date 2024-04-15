using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS34_Bud : MonoBehaviour
{
    [SerializeField] GS34_Flower selfFlower;
    GS34_FlowerGroup groupFlowers;

    // �N���b�N���ꂽ��
    // �E�ԃI�u�W�F�N�g���炩����i�\������j
    // �E���łɍ炢�Ă���ꍇ�͕ω����Ȃ�
    // �E�A������ԃI�u�W�F�N�g���炩����

    private void Awake()
    {
        selfFlower.SetSelfBut(this);
        groupFlowers = GetComponentInParent<GS34_FlowerGroup>();
    }

    public void OnClick()
    {
        Debug.Log("OnClick");
        selfFlower.Bloom(true);
        groupFlowers.Bloom();
    }

    // �ڂ݂Ƃ��ĕ\������
    public void ShowBud()
    {
        gameObject.SetActive(true);
    }
}
