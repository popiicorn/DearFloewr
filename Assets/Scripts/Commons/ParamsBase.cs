using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamsBase : MonoBehaviour
{
    public static ParamsBase Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }
}
