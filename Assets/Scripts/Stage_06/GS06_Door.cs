using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS06_Door : Gimmick
{
    public override Transform GetTargetPosition(Vector3 playerPos)
    {
        return transform;
    }

    public override void Move(Vector3 distance)
    {
        
    }

    public override void OnGameCharacter(Character character)
    {
        if (GetComponent<Animator>().enabled)
        {
            return;
        }
        character.ShowQuestionEmotion();
    }
}
