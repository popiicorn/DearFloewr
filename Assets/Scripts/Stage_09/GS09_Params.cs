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
        cameraShake.ShakeIntensity = ShakeIntensity;   // �J�����̗h��̋���
        cameraShake.ShakeDecay = ShakeDecay;      // �h��̌��Z�l
        cameraShake.ShakeAmount = 0.2f;       // �h��̋����W��
    }

    [Header("�u�����N����܂ł̎���")]
    public float delayTimeOfShake;
    [Header("�u���̋���")]
    public float ShakeIntensity;
    [Header("�u���̌����l")]
    public float ShakeDecay;
}
