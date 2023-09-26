using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EV03_Params : MonoBehaviour
{
    [SerializeField] FadeSpriteRenderer fadeSpriteRenderer;
    [SerializeField] CameraShake cameraShake;
    public static EV03_Params Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        cameraShake.delayTimeOfShake = delayTimeOfShake;
        fadeSpriteRenderer.fadeDurationOfDarkSky = fadeDurationOfDarkSky;
    }

    [Header("Clearで揺れるまでの時間")]
    public float delayTimeOfShake;
    [Header("闇フェード時間")]
    public float fadeDurationOfDarkSky;
}
