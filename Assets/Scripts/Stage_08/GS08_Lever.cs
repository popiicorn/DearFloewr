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

    // GS08_Buttonをインスペクター
    [SerializeField] GS08_Button button;
    bool wasCleared;


    // wasClearedをtrueにする   
    public void Clear()
    {
        wasCleared = true;
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

    // クリックされたら
    // ターゲットをこいつにしてPlayerが近づいてくる
    // 近くまできたら「Lever」をする

    public override void OnGameCharacter(Character character)
    {
        StartCoroutine(Anim(character));
    }

    IEnumerator Anim(Character character)
    {
        // Character移動不可
        character.canMove = false;
        character.BusyMode();
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().enabled = false;
        character.PushLeverButtonGimmick();
        yield return new WaitForSeconds(0.5f);
        OnPush?.Invoke();
        // buttonが押されていたら
        if (button.IsPushed)
        {
            character.SetDefaultMode();
            foreach (var eventData in eventDatas)
            {
                yield return eventData.Play();
            }
            if (wasCleared)
            {
                yield break;
            }
            character.enabled = true;
            character.canMove = true;
        }
        else
        {
            character.enabled = true;
            character.canMove = true;
            character.ShowQuestionEmotion();
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
