using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;

public class DoroneManager : MonoBehaviour
{
    [SerializeField] CriAtomSource atomSource;

    public void PlayDrone()
    {
        atomSource.Play(0);
    }

    public void StopDorone()
    {
        atomSource.Stop();
        atomSource.SetAisacControl("AisacControl_01", 0);
    }

    public void AisacController()
    {
        atomSource.SetAisacControl("AisacControl_01", 1);
    }
}

