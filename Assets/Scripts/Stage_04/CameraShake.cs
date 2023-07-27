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

    public UnityEvent OnShakedEvent;

    private Vector3 originPosition;
    private Quaternion originRotation;

    void Start()
    {
        originPosition = ShakeObject.localPosition;
        originRotation = ShakeObject.localRotation;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Do();
        }
    }

    public void Do()
    {
        StopAllCoroutines();
        StartCoroutine(Shake());
    }

    public IEnumerator Shake()
    {
        yield return new WaitForSeconds(Stage04Params.Instance.delayTimeOfShake);
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
}
