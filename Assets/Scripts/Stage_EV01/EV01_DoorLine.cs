using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EV01_DoorLine : Gimmick
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
        character.ShowQuestionEmotion();
    }
}
