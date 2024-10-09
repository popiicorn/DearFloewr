using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMDestroy : MonoBehaviour
{
    void Start()
    {
        if (BGMManager.Instance)
        {
            BGMManager.Instance.DestroyBGM();
        }
    }

    
}
