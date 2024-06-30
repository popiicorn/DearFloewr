using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;

public class loopSEManager : MonoBehaviour
{
    [SerializeField] CriAtomSource loopSEAtom01;
    [SerializeField] CriAtomSource loopSEAtom02;
    
    public void Playloop01()
    {
        loopSEAtom01.Play();
    }

    public void Playloop02()
    {
        loopSEAtom02.Play();
    }

    public void Stoploop()
    {
        loopSEAtom01.Stop();
        loopSEAtom02.Stop();
    }
}
