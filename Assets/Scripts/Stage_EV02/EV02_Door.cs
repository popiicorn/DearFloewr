using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EV02_Door : Gimmick
{
    [SerializeField] UnityEvent OnClear;
    public override Transform GetTargetPosition(Vector3 playerPos)
    {
        return transform;
    }

    public override void Move(Vector3 distance)
    {
    }

    public override void OnGameCharacter(Character character)
    {
        // 後ろ向きになってフェード
        character.SetWalkBackAnim();
        OnClear?.Invoke();
    }
}
