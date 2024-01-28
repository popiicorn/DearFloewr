using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
public class LightStone : Gimmick
{
    [SerializeField] int id;
    [SerializeField] GameObject lightEF;

    [SerializeField] Transform leftPos;
    [SerializeField] Transform rightPos;
    [SerializeField] UnityEvent OnLightON;
    [SerializeField] UnityEvent OnLightOFF;
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

    // クリックされたら
    // ターゲットをこいつにしてPlayerが近づいてくる
    // 近くまできたら「キック」をする
    // キックされたら特定の効果を実行する

    public override void OnGameCharacter(Character character)
    {
        StartCoroutine(Anim(character));
    }

    IEnumerator Anim(Character character)
    {
        character.BusyMode();
        yield return new WaitForSeconds(0.5f);
        character.KickGimmick();
        yield return new WaitForSeconds(0.2f);
        yield return Shake();
        // yield return new WaitForSeconds(0.3f);
        if (LightStoneManager.Instance.IsCorrect(id))
        {
            lightEF.SetActive(true);
            OnLightON?.Invoke();
        }
        else
        {
            OnLightOFF?.Invoke();
        }
        character.SetDefaultMode();
    }

    public void LightOff()
    {
        lightEF.SetActive(false);
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
