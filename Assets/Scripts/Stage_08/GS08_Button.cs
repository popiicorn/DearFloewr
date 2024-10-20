using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS08_Button : Gimmick
{

    [SerializeField] Transform leftPos;
    [SerializeField] Transform rightPos;
    public UnityEvent OnPush;
    bool isPushed;

    public bool IsPushed { get => isPushed; }

    // isPushedをFalseにする
    public void ResetIsPushed()
    {
        isPushed = false;
    }
    // isPushedをTrueにする
    public void SetIsPushed()
    {
        isPushed = true;
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
        OnPush?.Invoke();
        // 絵柄を切り替える
        character.SetDefaultMode();
    }
}

