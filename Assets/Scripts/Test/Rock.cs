using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Gimmick
{
    [SerializeField] Transform leftPos;
    [SerializeField] Transform rightPos;
    private void Awake()
    {
        Size = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    public override Transform GetTargetPosition(Vector3 playerPos)
    {
        if (transform.position.x < playerPos.x)
        {
            return rightPos;
        }
        return leftPos;
    }

    public void SetLock(bool value)
    {
        IsLock = value;
    }

    public override void Move(Vector3 distance)
    {
        if (IsLock)
        {
            return;
        }
        transform.position += distance;
    }

    // 状態を
    public override void OnGameCharacter(Character character)
    {
        character.SetPushMode();
    }
}