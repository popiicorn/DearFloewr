using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS33_FlowerManager : MonoBehaviour
{
    // �q�v�f�̉Ԃ̃��X�g
    GS33_Flower[] flowers;
    int count = 0;

    // �S�ẲԂ��N���b�N�������̃C�x���g
    public UnityEvent OnClickAllFlowers;


    void Start()
    {
        // �q�v�f�̉Ԃ̃��X�g���擾
        flowers = GetComponentsInChildren<GS33_Flower>(true);

        // �Ԃ̃N���b�N���̏�����ݒ�
        foreach (var flower in flowers)
        {
            flower.OnClickAction = OnClickFlower;
        }
    }

    // �Ԃ��N���b�N���ꂽ���̏���
    void OnClickFlower()
    {
        Debug.Log("�Ԃ��N���b�N���ꂽ");
        count++;
        if (count == flowers.Length)
        {
            OnClickAllFlowers?.Invoke();
        }
    }

}
