using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS08_Lever : Gimmick
{

    [SerializeField] Transform leftPos;
    [SerializeField] Transform rightPos;
    public UnityEvent OnPush;
    [SerializeField] EventData[] eventDatas;

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
        foreach (var eventData in eventDatas)
        {
            yield return eventData.Play();
        }
    }

}

[System.Serializable]
public class EventData
{
    public float delay;
    public UnityEvent unityEvent;

    public IEnumerator Play()
    {
        yield return new WaitForSeconds(delay);
        unityEvent.Invoke();
    }
}
