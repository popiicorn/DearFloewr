using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS14_Lever : GS07_Lever
{
    protected override IEnumerator Anim(Character character)
    {
        Debug.Log("Anim");
        character.canMove = false;
        character.BusyMode();
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().enabled = false;
        character.PushLeverButtonGimmick();
        character.enabled = false;
        yield return new WaitForSeconds(0.5f);
        if (!isClear)
        {
            OnPush?.Invoke();
        }
        GetComponent<SpriteRenderer>().enabled = true;
        character.SetDefaultMode();
        yield return new WaitForSeconds(2f);
        // ŠG•¿‚ğØ‚è‘Ö‚¦‚é
        character.SetDefaultMode();
        character.canMove = true;
    }
}

