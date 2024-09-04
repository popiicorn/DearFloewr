using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;

public class NoiseManager : MonoBehaviour
{
    public CriAtomSource atomSource;
    bool push=false;
    

    public void PlayNoise()
    {
        if (push==false)
        {
            atomSource.Play(1);
            push = true;
        }
        else if (push==true)
        {
            StopNoise();
            push = false;
        }
    }

    void Noise()
    {
        
    }
    public void StopNoise()
    {
        atomSource.Stop();
    }
}
