using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS28_Lever : Gimmick
{

    [SerializeField] Transform leftPos;
    [SerializeField] Transform rightPos;
    public EventData[] EventDatas;
    bool isClear = false;
    bool canMove = false;

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
        Debug.Log("Anim");
        character.canMove = false;
        character.BusyMode();
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().enabled = false;
        character.PushLeverButtonGimmick();
        yield return new WaitForSeconds(0.5f);
        GetComponent<SpriteRenderer>().enabled = true;
        if (!canMove)
        {
            character.ShowQuestionEmotion();
            yield return new WaitForSeconds(1f);
        }
        else if (!isClear)
        {
            foreach (var eventData in EventDatas)
            {
                yield return eventData.Play();
            }
        }

        // 絵柄を切り替える
        character.SetDefaultMode();
        character.canMove = true;
    }

    public void SetClearFlag()
    {
        isClear = true;
    }

    public void SetCanMove()
    {
        canMove = true;
    }
}


