using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage22Params : MonoBehaviour
{
    public static Stage22Params Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
}
