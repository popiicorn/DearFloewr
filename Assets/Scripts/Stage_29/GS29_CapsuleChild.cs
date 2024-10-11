using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS29_CapsuleChild : MonoBehaviour
{
    int count = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        count++;
        if (count < 3)
        {
            return;
        }
        CriManager.instance.PlayObjSE("CupcellRolling");
    }
}
