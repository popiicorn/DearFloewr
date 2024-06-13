using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS17_SmallRockEvent : MonoBehaviour
{
    // �{�[�i�X�̉�
    [SerializeField] float getTime;
    [SerializeField] GameObject getFlower;
    [SerializeField] Character character;
    bool isGetFlower;

    // �����L������5�b�����Ă�����A�Ԃ��擾

    float timer;

    private void Update()
    {
        if (isGetFlower)
        {
            return;
        }
        Debug.Log(character.CharaMode);
        if (character.CharaMode == Character.Mode.Sit)
        {
            timer += Time.deltaTime;
            if (timer >= getTime)
            {
                getFlower.SetActive(true);
                isGetFlower = true;
            }
        }
        else
        {
            timer = 0;
        }
    }
}
