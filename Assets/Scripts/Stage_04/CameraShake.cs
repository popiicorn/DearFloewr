using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraShake : MonoBehaviour
{
    [Header("Shake")]
    public Transform ShakeObject = null;   // ここにカメラオブジェクトを設定する
    public float ShakeIntensity = 0.02f;   // カメラの揺れの強さ
    public float ShakeDecay = 0.002f;      // 揺れの減算値
    public float ShakeAmount = 0.2f;       // 揺れの強さ係数
    public float delayTimeOfShake;

    public UnityEvent OnShakedEvent;

    private Vector3 originPosition;
    private Quaternion originRotation;

    void Start()
    {
        originPosition = ShakeObject.localPosition;
        originRotation = ShakeObject.localRotation;
    }


    public void Do()
    {
        StopAllCoroutines();
        StartCoroutine(Shake());
    }

    public IEnumerator Shake()
    {
        yield return new WaitForSeconds(delayTimeOfShake);
        float shakeIntensity = ShakeIntensity;
        while (shakeIntensity > 0)
        {
            ShakeObject.localPosition = originPosition + Random.insideUnitSphere * shakeIntensity;
            ShakeObject.localRotation = new Quaternion(
                originRotation.x + Random.Range(-shakeIntensity, shakeIntensity) * ShakeAmount,
                originRotation.y + Random.Range(-shakeIntensity, shakeIntensity) * ShakeAmount,
                originRotation.z + Random.Range(-shakeIntensity, shakeIntensity) * ShakeAmount,
                originRotation.w + Random.Range(-shakeIntensity, shakeIntensity) * ShakeAmount);
            shakeIntensity -= ShakeDecay;
            yield return false;
        }
        ShakeObject.localPosition = originPosition;
        ShakeObject.localRotation = originRotation;
        OnShakedEvent?.Invoke();
    }
    public IEnumerator ShakeLoop(float spanTime, float power)
    {
        // 揺れる

        while (true)
        {
            ShakeObject.localRotation = Quaternion.Euler(0, 0, power);
            yield return new WaitForSeconds(spanTime);
            ShakeObject.localRotation = Quaternion.Euler(0, 0, -power);
            yield return new WaitForSeconds(spanTime);
        }
    }

    public IEnumerator Shake(float spanTime, float power, float time)
    {
        // 揺れる
        float sumTime = 0;
        while (sumTime < time)
        {
            ShakeObject.localRotation = Quaternion.Euler(0, 0, power);
            yield return new WaitForSeconds(spanTime);
            if (sumTime > time)
            {
                break;
            }
            ShakeObject.localRotation = Quaternion.Euler(0, 0, -power);
            yield return new WaitForSeconds(spanTime);
            sumTime += spanTime * 2;
        }
        ShakeObject.localRotation = Quaternion.Euler(0, 0, 0);
    }


}
