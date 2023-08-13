using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS07_Lever : Gimmick
{

    [SerializeField] Transform leftPos;
    [SerializeField] Transform rightPos;
    public UnityEvent OnPush;

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
    // �߂��܂ł�����uLever�v������

    public override void OnGameCharacter(Character character)
    {
        StartCoroutine(Anim(character));
    }

    IEnumerator Anim(Character character)
    {
        character.BusyMode();
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().enabled = false;
        character.PushLeverButtonGimmick();
        yield return new WaitForSeconds(0.5f);
        OnPush?.Invoke();
        // �G����؂�ւ���
        character.SetDefaultMode();
        character.ShowQuestionEmotion();
    }
}

