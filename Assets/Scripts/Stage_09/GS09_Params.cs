using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS09_Params : MonoBehaviour
{
    [SerializeField] CameraShake cameraShake;
    public static GS09_Params Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        cameraShake.delayTimeOfShake = delayTimeOfShake;
        cameraShake.ShakeIntensity = ShakeIntensity;   // カメラの揺れの強さ
        cameraShake.ShakeDecay = ShakeDecay;      // 揺れの減算値
        cameraShake.ShakeAmount = 0.2f;       // 揺れの強さ係数
    }

    [Header("ブレが起こるまでの時間")]
    public float delayTimeOfShake;
    [Header("ブレの強さ")]
    public float ShakeIntensity;
    [Header("ブレの減衰値")]
    public float ShakeDecay;
}
