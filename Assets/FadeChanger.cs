using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;
using DG.Tweening;

public class FadeChanger : MonoBehaviour
{
    [SerializeField] CriAtomSource playerAtomSource;

    public void FadeSound()
    {
        Debug.Log("FedeOut");
        DOVirtual.Float(0f, 1f, 5f, value =>
        {
            playerAtomSource.SetAisacControl("Filter", value);
        });
    }
}
