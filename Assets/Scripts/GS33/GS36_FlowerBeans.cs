using JetBrains.Annotations;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class GS36_FlowerBeans : Gimmick
{
    [SerializeField] int id;
    [SerializeField] Transform rightPos;

    [SerializeField] EventData[] eventDatas;
    public UnityAction<int> OnSelected;

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
        StartCoroutine(OnPlayer(character));
    }

    IEnumerator OnPlayer(Character character)
    {
        character.SetDefaultMode();
        IsLock = true;
        character.enabled = false;
        yield return new WaitForSeconds(0.3f);
        OnSelected?.Invoke(id);
        character.PushLeverButtonGimmick();
        yield return new WaitForSeconds(0.5f);
        foreach (var eventData in eventDatas)
        {
            yield return eventData.Play();
        }
    }
}
