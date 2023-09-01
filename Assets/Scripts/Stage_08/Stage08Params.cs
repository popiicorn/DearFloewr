using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage08Params : MonoBehaviour
{
    [SerializeField] FadeSpriteRenderer fadeSpriteRenderer;
    [SerializeField] CameraShake cameraShake;
    public static Stage08Params Instance { get; private set; }
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
        fadeSpriteRenderer.fadeDurationOfDarkSky = fadeDurationOfDarkSky;
    }

    [Header("�u�����N����܂ł̎���")]
    public float delayTimeOfShake;
    [Header("�u���̋���")]
    public float ShakeIntensity;
    [Header("�u���̌����l")]
    public float ShakeDecay;

    [Header("�Ńt�F�[�h���Ȃ��Ȃ�b��")]
    public float fadeDurationOfDarkSky;
}
