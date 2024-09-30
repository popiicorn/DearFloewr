using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;
using DG.Tweening;


public class SingleBGMManager : MonoBehaviour
{
    public static SingleBGMManager instance;
    private void Awake()
    {
        instance = this;
    }
    public CriAtomSource bGMAtomSource;
    public string bGMCueName;

    public void StartBGM(string cueName)
    {
        bGMAtomSource.Play(cueName);
    }

    public void StopBGM()
    {

        bGMAtomSource.Stop();
    }

    public void OffAisac()
    {
        DOVirtual.Float(0.7f, 0f, 3f, value =>
        {
            bGMAtomSource.SetAisacControl("Filter", value);
        });

    }

    public void OnBGMAisac(string aisacName)
    {
        DOVirtual.Float(0f, 1f, 1f, value =>
        {
            bGMAtomSource.SetAisacControl(aisacName, value);
        });
    }


    }
