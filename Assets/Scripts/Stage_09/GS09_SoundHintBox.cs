using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS09_SoundHintBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("HintBox Triggered");
        CriManager.instance.PlayObjSE("hithint");
    }
}
