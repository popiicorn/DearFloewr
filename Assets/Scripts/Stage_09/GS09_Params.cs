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
        cameraShake.ShakeIntensity = ShakeIntensity;   // ƒJƒƒ‰‚Ì—h‚ê‚Ì‹­‚³
        cameraShake.ShakeDecay = ShakeDecay;      // —h‚ê‚ÌŒ¸Z’l
        cameraShake.ShakeAmount = 0.2f;       // —h‚ê‚Ì‹­‚³ŒW”
    }

    [Header("ƒuƒŒ‚ª‹N‚±‚é‚Ü‚Å‚ÌŠÔ")]
    public float delayTimeOfShake;
    [Header("ƒuƒŒ‚Ì‹­‚³")]
    public float ShakeIntensity;
    [Header("ƒuƒŒ‚ÌŒ¸Š’l")]
    public float ShakeDecay;
}
