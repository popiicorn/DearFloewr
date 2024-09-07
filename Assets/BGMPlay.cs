using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;

public class BGMPlay : MonoBehaviour
{
    [SerializeField] CriAtomSource bGMSource;
    [SerializeField] string queName;
    
    void Start()
    {
        Invoke("PlayBGM",0.1f);
    }

    public void PlayBGM()
    {
        CriAtomSource.Status status00 = bGMSource.status;
        if (status00 != CriAtomSource.Status.Playing)
        {
            bGMSource.Play(queName);
        }
        else { }
    }

    public void StopBGM()
    {
        bGMSource.Stop();
    }
}
