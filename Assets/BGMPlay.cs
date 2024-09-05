using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;

public class BGMPlay : MonoBehaviour
{
    //[SerializeField] CriAtomSource bGMSource;
    [SerializeField] string queName;
    
    void Start()
    {
        Invoke("PlayBGM",0.2f);
    }

    public void PlayBGM()
    {
        CriAtomSource.Status status00 = BGMManager.Instance.bGMAtomSource.status;
        if (status00 != CriAtomSource.Status.Playing)
        {
            BGMManager.Instance.StartBGM(queName);
        }
        else { }
    }
}
