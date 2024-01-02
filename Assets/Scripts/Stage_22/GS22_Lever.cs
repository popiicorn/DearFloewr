using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS22_Lever : GS20_Lever
{
    // �t���O�����������ǂ����𔻒肷�邽�߂̕ϐ�
    bool canMove = false;

    public void SetCanMove(bool canMove)
    {
        this.canMove = canMove;
    }
    override protected IEnumerator Play()
    {
        isOn = true;
        isPlaying = true;
        animator.Play("lever_Solo");
        if (!canMove)
        {
            isPlaying = false;
            yield break;
        }
        foreach (var eventData in eventDatas)
        {
            yield return eventData.Play();
        }
        isPlaying = false;
    }

}
