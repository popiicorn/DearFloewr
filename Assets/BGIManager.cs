using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;
using DG.Tweening;

public class BGIManager : MonoBehaviour
{
    [SerializeField] CriAtomSource bGMItomSource;
    [SerializeField] CriAtomSource bGMItomSource01;

    public static BGIManager instance;
    private void Awake()
    {
        instance = this;
    }

    public void OnAisac()
    {
        DOVirtual.Float(0f, 0.7f, 1f, value =>
        {
            bGMItomSource.SetAisacControl("Filter", value);
        });
        if (bGMItomSource01 != null)
        {
            DOVirtual.Float(0f, 0.7f, 1f, value =>
            {
                bGMItomSource01.SetAisacControl("Filter", value);
            });
        }


    }

    public void OffAisac()
    {
        DOVirtual.Float(0.7f, 0f,1f, value =>
        {
            bGMItomSource.SetAisacControl("Filter", value);
        });
        if (bGMItomSource01 != null)
        {
            DOVirtual.Float(0.7f, 0f, 1f, value =>
            {
                bGMItomSource01.SetAisacControl("Filter", value);
            });
        }

    }
}
