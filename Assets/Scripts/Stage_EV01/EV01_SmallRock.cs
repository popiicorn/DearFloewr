using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EV01_SmallRock : Gimmick
{
    [SerializeField] Transform leftPos;
    [SerializeField] Transform rightPos;
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
    }

    public override void OnGameCharacter(Character character)
    {
        // 座るアニメーションをする
        character.SitGimmick();
        if (CriManager.instance.stage11== true)
        {
           CriManager.instance.PlayObjSE("SitPoint");
        }

    }
}
