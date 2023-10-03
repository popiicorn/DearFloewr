using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EV03_Params : MonoBehaviour
{
    [SerializeField] FadeSpriteRenderer fadeSpriteRenderer;
    [SerializeField] CameraShake cameraShake;
    [SerializeField] float timeCamera;
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

    [Range(0.1f,3)]
    public float cameraMoveTime;
    [Header("Clear�ŗh���܂ł̎���")]
    public float delayTimeOfShake;
    [Header("�Ńt�F�[�h����")]
    public float fadeDurationOfDarkSky;
}
