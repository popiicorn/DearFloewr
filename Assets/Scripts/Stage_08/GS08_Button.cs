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

    // isPushed‚ðFalse‚É‚·‚é
    public void ResetIsPushed()
    {
        isPushed = false;
    }
    // isPushed‚ðTrue‚É‚·‚é
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
        // ŠG•¿‚ðØ‚è‘Ö‚¦‚é
        character.SetDefaultMode();
    }
}

