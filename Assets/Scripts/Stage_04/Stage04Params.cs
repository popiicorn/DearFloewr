using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage04Params : MonoBehaviour
{
    public static Stage04Params Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    [Header("Clearで揺れるまでの時間")]
    public float delayTimeOfShake;
    [Header("闇フェード時間")]
    public float fadeDurationOfDarkSky;
}
