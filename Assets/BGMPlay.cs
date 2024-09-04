using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;

public class BGMPlay : MonoBehaviour
{
    [SerializeField] CriAtomSource bGMSource;
    [SerializeField] string queName;
    // Start is called before the first frame update
    void Start()
    {
        PlayBGM();
    }

    void PlayBGM()
    {
        CriAtomSource.Status status00 = bGMSource.status;
        if (status00 != CriAtomSource.Status.Playing)
        {
            bGMSource.Play(queName);
        }
        else { }
    }
}
