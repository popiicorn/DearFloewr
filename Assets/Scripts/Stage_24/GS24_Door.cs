using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GS24_Door : Gimmick, IPointerDownHandler
{
    enum KnockType
    {
        Right,
        Left,
    }

    // �����̃m�b�N�̏���
    [SerializeField] KnockType[] knockTypes;
    int knockIndex = 0;

    bool canKnock = false;
    bool isRightKnock = true;
    bool isClear = false;
    [SerializeField] EventData[] OnClearEvent;
    // ���o�[���������܂ł́A�N���b�N����Ă��L�������߂Â��āH���ł邾��
    // ���o�[�������ꂽ��A�N���b�N�����ƃL�������߂Â��āA�m�b�N�A�j���[�V����������
    public override Transform GetTargetPosition(Vector3 playerPos)
    {
        return transform;
    }


    public override void Move(Vector3 distance)
    {
    }

    public override void OnGameCharacter(Character character)
    {
        if (isClear)
        {
            character.SetDefaultMode();
            return;
        }
        if (!canKnock)
        {
            character.ShowQuestionEmotion();
        }
        else
        {
            StartCoroutine(Anim(character));
            // character.SetDefaultMode();
        }
    }

    IEnumerator Anim(Character character)
    {
        character.BusyMode();
        yield return new WaitForSeconds(0.1f);
        character.ShowNockAnim(isRightKnock);
        CheckCorrectKnock(isRightKnock);
        yield return new WaitForSeconds(0.3f);
        character.SetDefaultMode();
    }


    public void SetCanKnock(bool value)
    {
        canKnock = value;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // �N���b�N���ꂽ���W�����O�ɕ\��
        float diff = eventData.pointerCurrentRaycast.worldPosition.x - transform.position.x;
        isRightKnock = diff >= 0;
    }

    // �m�b�N�����Ԃ����������ǂ������f����
    public void CheckCorrectKnock(bool isRightKnock)
    {
        KnockType currentKnockType = isRightKnock ? KnockType.Right : KnockType.Left;

        if (knockTypes[knockIndex] != currentKnockType)
        {
            knockIndex = 0;
            canKnock = false;
            return;
        }
        knockIndex++;
        if (knockIndex >= knockTypes.Length)
        {
            canKnock = false;
            isClear = true;
            StartCoroutine(PlayClearEvent());
        }
    }

    IEnumerator PlayClearEvent()
    {
        foreach (var eventData in OnClearEvent)
        {
            yield return eventData.Play();
        }
    }
}
