using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS17_SmallRockEvent : MonoBehaviour
{
    // �{�[�i�X�̉�
    [SerializeField] float getTime;
    [SerializeField] BornuthFlower getFlower;
    [SerializeField] Character character;
    bool isGetFlower;

    // �����L������5�b�����Ă�����A�Ԃ��擾

    float timer;
    bool isSit;
    void Start()
    {
        isGetFlower = getFlower.WasGet;
    }

    private void Update()
    {
        if (isGetFlower)
        {
            return;
        }
        if (character.CharaMode == Character.Mode.Sit)
        {
            timer += Time.deltaTime;
            if (timer >= getTime)
            {
                getFlower.ShowFlower();
                isGetFlower = true;
            }
            if (!isSit)
            {
                CriManager.instance.PlayObjSE("hinto");
                Debug.Log("�����Ă�");
            }

            isSit = true;
        }
        else
        {
            timer = 0;
            if (isSit)
            {
                CriManager.instance.StopObjSE();
                Debug.Log("�����Ă�");
            }
            isSit = false;
        }
    }
}
