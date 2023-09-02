using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS09_Rock : Gimmick
{
    [SerializeField] Transform leftPos;
    [SerializeField] Transform rightPos;
    [SerializeField] float timeOfActive;


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
        character.ShowQuestionEmotion();
    }
}