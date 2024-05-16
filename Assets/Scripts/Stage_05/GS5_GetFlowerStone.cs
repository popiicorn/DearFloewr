using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS5_GetFlowerStone : Gimmick
{
    // Î‚ªR‚ç‚ê‚½‚çÎ‚ð—h‚ç‚·
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
        kickCount++;
        if (kickCount == 5)
        {
            GetComponent<Collider2D>().enabled = false;
        }
        character.BusyMode();
        yield return new WaitForSeconds(0.5f);
        character.KickGimmick();
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(Shake());
        if (kickCount == 5)
        {
            flower.SetActive(true);
            GetComponent<Collider2D>().enabled = false;
            wasGetFlower = true;
        }
        character.SetDefaultMode();
    }

    [Header("Shake")]
    public float ShakeIntensity = 0.02f;   // ƒJƒƒ‰‚Ì—h‚ê‚Ì‹­‚³
    public float ShakeDecay = 0.002f;      // —h‚ê‚ÌŒ¸ŽZ’l
    public float ShakeAmount = 0.2f;       // —h‚ê‚Ì‹­‚³ŒW”

    private Vector3 originPosition;
    private Quaternion originRotation;

    void Start()
    {
        originPosition = transform.localPosition;
        originRotation = transform.localRotation;
    }

    public IEnumerator Shake()
    {
        float shakeIntensity = ShakeIntensity;
        while (shakeIntensity > 0)
        {
            transform.localPosition = originPosition + Random.insideUnitSphere * shakeIntensity;
            transform.localRotation = new Quaternion(
                originRotation.x + Random.Range(-shakeIntensity, shakeIntensity) * ShakeAmount,
                originRotation.y + Random.Range(-shakeIntensity, shakeIntensity) * ShakeAmount,
                originRotation.z + Random.Range(-shakeIntensity, shakeIntensity) * ShakeAmount,
                originRotation.w + Random.Range(-shakeIntensity, shakeIntensity) * ShakeAmount);
            shakeIntensity -= ShakeDecay;
            yield return false;
        }
        transform.localPosition = originPosition;
        transform.localRotation = originRotation;
    }
}
