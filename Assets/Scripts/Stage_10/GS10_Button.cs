using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS10_Button : Gimmick
{
    [SerializeField] EventData[] eventDatas;
    public bool canPush = false;
    [SerializeField] Transform leftPos;
    [SerializeField] Transform rightPos;

    public void SetCanPush(bool canPush)
    {
        this.canPush = canPush;
    }

    public override Transform GetTargetPosition(Vector3 playerPos)
    {
        if (transform.position.x < playerPos.x)
        {
            return rightPos;
        }
        return leftPos;
    }

    public override void Move(Vector3 distance)
    {
        Debug.LogError("ERROR");
    }

    // �N���b�N���ꂽ��
    // �^�[�Q�b�g�������ɂ���Player���߂Â��Ă���
    // �߂��܂ł�����u�L�b�N�v������
    // �L�b�N���ꂽ�����̌��ʂ����s����

    public override void OnGameCharacter(Character character)
    {
        StartCoroutine(Anim(character));
    }

    IEnumerator Anim(Character character)
    {
        character.BusyMode();
        yield return new WaitForSeconds(0.2f);
        character.PushButtonGimmick();
        yield return new WaitForSeconds(0.1f);
        if (canPush)
        {
            StartCoroutine(AllPlayAnim());
            character.SetDefaultMode();
        }
        else
        {
            character.ShowQuestionEmotion();
        }
    }
    IEnumerator AllPlayAnim()
    {
        foreach (var eventData in eventDatas)
        {
            yield return eventData.Play();
        }
    }
}
