using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage05Params : MonoBehaviour
{
    public static Stage05Params Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public float fadeDurationOfShadow;
}
