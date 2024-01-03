using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS24_Params : ParamsBase
{
    [SerializeField] CameraShake cameraShake;
    [SerializeField] GS24_CameraMove cameraMove;

    void Start()
    {
        cameraShake.ShakeIntensity = ShakeIntensity;
        cameraShake.ShakeDecay = ShakeDecay;
        cameraShake.ShakeAmount = ShakeAmount;

    }

    [SerializeField] float ShakeIntensity = 0.1f;   // ƒJƒƒ‰‚Ì—h‚ê‚Ì‹­‚³
    [SerializeField] float ShakeDecay = 0.001f;      // —h‚ê‚ÌŒ¸Z’l
    [SerializeField] float ShakeAmount = 0.1f;       // —h‚ê‚Ì‹­‚³ŒW”

    [SerializeField] float cameraMoveSpeed = 1f;

}
