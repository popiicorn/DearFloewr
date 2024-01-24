using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;

public class GS_31_Door : Gimmick
{
    [SerializeField] Transform leftPos;
    [SerializeField] Transform rightPos;

    [SerializeField] EventData[] eventDatas;

    public override Transform GetTargetPosition(Vector3 playerPos)
    {
        if (transform.position.x < playerPos.x)
        {

            return rightPos;
        }
        return rightPos;
    }

    public override void Move(Vector3 distance)
    {
    }

    public override void OnGameCharacter(Character character)
    {
        StartCoroutine(OnDoorClick());
    }

    IEnumerator OnDoorClick()
    {
        foreach (var eventData in eventDatas)
        {
            yield return eventData.Play();
        }
    }
}
