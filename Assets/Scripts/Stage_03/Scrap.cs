using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrap : Gimmick
{
    [SerializeField] Transform leftPos;
    [SerializeField] Transform rightPos;
    [SerializeField] float timeOfActive;
    WaitForSeconds wait;

    private void Awake()
    {
        wait = new WaitForSeconds(timeOfActive);
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
        character.SetDefaultMode();
        yield return new WaitForSeconds(0.1f);
        character.ShowQuestionEmotion(true);
        yield return wait;
        character.ShowQuestionEmotion(false);
    }
}