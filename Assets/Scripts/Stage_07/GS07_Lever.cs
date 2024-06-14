using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS07_Lever : Gimmick
{

    [SerializeField] Transform leftPos;
    [SerializeField] Transform rightPos;
    [SerializeField] List<EventData> eventDatas;
    public UnityEvent OnPush;
    protected bool isClear = false;

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

    protected virtual IEnumerator Anim(Character character)
    {
        Debug.Log("Anim");
        character.canMove = false;
        character.BusyMode();
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().enabled = false;
        character.PushLeverButtonGimmick();
        character.enabled = false;
        yield return new WaitForSeconds(0.5f);
        if (!isClear)
        {
            OnPush?.Invoke();
            foreach (var eventData in eventDatas)
            {
                yield return eventData?.Play();
            }
        }
        GetComponent<SpriteRenderer>().enabled = true;
        character.SetDefaultMode();
        yield return new WaitForSeconds(2f);
        // 絵柄を切り替える
        character.SetDefaultMode();
        character.canMove = true;
    }


    public void SetClearFlag()
    {
        isClear = true;
    }
}

