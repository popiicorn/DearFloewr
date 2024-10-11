using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GS28_Box : Gimmick, IRockable
{
    [SerializeField] int id;
    [SerializeField] Transform leftPos;
    [SerializeField] Transform rightPos;

    public int Id { get => id; }

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
        if (IsLock)
        {
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(GetComponent<Collider2D>());
            Destroy(this);
        }
    }

    public override void Move(Vector3 distance)
    {
        if (IsLock)
        {
            return;
        }
        transform.position += distance;
        if (distance.sqrMagnitude < float.Epsilon)
        {
            IsMove = false;
        }
        else
        {
            IsMove = true;
        }
        // rightLimitにとどいたら
        if (transform.position.x > GetRightLimit().position.x - limitOffsetR)
        {
            OnLimit?.Invoke();
        }
    }

    // 状態を
    public override void OnGameCharacter(Character character)
    {
        IsMove = false;
        character.SetPushMode();
        if (transform.position.x < character.transform.position.x)
        {
            // character.ExitLimit = false;
        }
        else
        {
            // character.ExitLimit = true;
        }
    }
}
