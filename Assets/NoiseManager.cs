using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;

public class NoiseManager : MonoBehaviour
{
    [SerializeField] CriAtomSource atomSource;
    bool push=false;
    

    public void PlayNoise()
    {
        Debug.Log("push");
        if (push==false)
        {
            atomSource.Play(1);
            push = true;
            Debug.Log("on");
        }
        else if (push==true)
        {
            StopNoise();
            push = false;
            Debug.Log("off");
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
