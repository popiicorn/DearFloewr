using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class GS29_Hole : Gimmick
{
    [SerializeField] Transform leftPos;
    [SerializeField] Transform rightPos;
    [SerializeField] EventData[] eventDatas;
    [SerializeField] Character character;
    [SerializeField] AnimatorOverrideController animatorOverrideController;

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
        Animator animator = GetComponent<Animator>();
    }

    public override void OnGameCharacter(Character character)
    {
        StartCoroutine(PlayEvent());
    }

    IEnumerator PlayEvent()
    {
        foreach (var eventData in eventDatas)
        {
            yield return eventData.Play();
        }

        Vector3 pos = character.transform.position;
        pos.x = 20;
        character.transform.position = pos;
    }

    public void SetMode()
    {
        character.SetAnim(animatorOverrideController);
    }

    public void SetIgnore()
    {
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<GS29_Box>())
        {
            gameObject.layer = 0;    
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<GS29_Box>())
        {
            gameObject.layer = 2;
        }
    }
} 