using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS5_GetFlowerStone : Gimmick
{
    // Î‚ðR‚Á‚½‚ç‰æ–ÊƒuƒŒ
    [SerializeField] CameraShake cameraShake;
    public Transform leftPos;
    public Transform rightPos;
    // Î‚ð‚T‰ñR‚Á‚½‚ç‰Ô‚ðŽæ“¾
    [SerializeField] GameObject flower;
    int kickCount = 0;
    [SerializeField] Transform target;
    bool canKick = false;
    bool wasGetFlower = false;
    private void Update()
    {
        if (wasGetFlower)
        {
            return;
        }
        if (!canKick && target.position.x >= 28.7f)
        {
            canKick = true;
            GetComponent<Collider2D>().enabled = true;
        }
        else if (canKick && target.position.x < 28.7f)
        {
            canKick = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    public override Transform GetTargetPosition(Vector3 playerPos)
    {
        IsMove = false;
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
        StartCoroutine(Anim(character));
    }

    IEnumerator Anim(Character character)
    {
        character.BusyMode();
        yield return new WaitForSeconds(0.5f);
        character.KickGimmick();
        kickCount++;
        yield return new WaitForSeconds(0.2f);
        if (cameraShake)
        {
            StartCoroutine(cameraShake.Shake(0.02f, 0.7f, 10f / 60f));
        }
        if (kickCount == 5)
        {
            flower.SetActive(true);
            GetComponent<Collider2D>().enabled = false;
            wasGetFlower = true;
        }
        character.SetDefaultMode();
    }
}
