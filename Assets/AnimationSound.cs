using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;

public class AnimationSound : MonoBehaviour
{
    [SerializeField] CriAtomSource atomSource;
    // Start is called before the first frame update
   public void PlayAnimSE(string cueName)
    {
        atomSource.Play(cueName);
    }

    public void StopAnimSE()
    {
        atomSource.Stop();
    }
    
}
