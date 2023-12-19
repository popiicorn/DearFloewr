using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage17Params : MonoBehaviour
{
    public static Stage17Params Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    public float shakeSpan = 0.05f;
    public float shakeAmount = 0.3f;
    public float shakeTime = 0.5f;
}
