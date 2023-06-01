using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;


public class FootStepSE : MonoBehaviour
{
    [SerializeField] CriAtomSource atomSource;

    public void PlaysSE(int cueNum)
    {
        atomSource.Play(cueNum);
    }
}
