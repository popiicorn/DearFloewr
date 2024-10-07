using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMDestroy : MonoBehaviour
{
    void Start()
    {
        BGMManager.Instance.DestroyBGM();
    }

    
}
