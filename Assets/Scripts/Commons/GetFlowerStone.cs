using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFlowerStone : Gimmick
{
    // 石が蹴られたら石を揺らす
    public Transform leftPos;
    public Transform rightPos;
    // 石を５回蹴ったら花を取得
    [SerializeField] protected BornuthFlower flower;
    // 石を蹴る回数
    [SerializeField] protected int kickCount = 5;
    protected int currentKickCount = 0;
    protected bool canKick = false;
    protected bool wasGetFlower = false;
    protected virtual void Update()
    {
        if (wasGetFlower)
        {
            return;
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
        Debug.Log("OnGameCharacter");
    }

    IEnumerator Anim(Character character)
    {
        currentKickCount++;
        if (currentKickCount == kickCount)
        {
            GetComponent<Collider2D>().enabled = false;
        }
        character.BusyMode();
        yield return new WaitForSeconds(0.5f);
        character.KickGimmick();
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(Shake());
        Debug.Log("Anim");
        if (currentKickCount == kickCount)
        {
            flower.ShowFlower();
            GetComponent<Collider2D>().enabled = false;
            wasGetFlower = true;
            CriManager.instance.PlayUISE("flowerGet");
        }
        character.SetDefaultMode();
    }

    [Header("Shake")]
    public float ShakeIntensity = 0.02f;   // カメラの揺れの強さ
    public float ShakeDecay = 0.002f;      // 揺れの減算値
    public float ShakeAmount = 0.2f;       // 揺れの強さ係数

    private Vector3 originPosition;
    private Quaternion originRotation;

    void Start()
    {
        originPosition = transform.localPosition;
        originRotation = transform.localRotation;
        wasGetFlower = flower.WasGet;
        if (wasGetFlower)
        {
            GetComponent<Collider2D>().enabled = false;
        }
    }

    public IEnumerator Shake()
    {
        float shakeIntensity = ShakeIntensity;
        Debug.Log("Shake"+ shakeIntensity);
        while (shakeIntensity > 0)
        {
            Debug.Log("Shake"+ shakeIntensity);
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
