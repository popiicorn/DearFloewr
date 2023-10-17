using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;


public class FootStepSE : MonoBehaviour
{
    [SerializeField] CriAtomSource atomSource;
    [SerializeField] STAGE_TYPE sTAGE_TYPE;
    public enum STAGE_TYPE 
    { 
        WILDNESS,
        FACTRY,
    
    }

    public void PlaysSE()
    {
        string cueName;
        if (sTAGE_TYPE==STAGE_TYPE.FACTRY)
        {
            cueName = "footStep00";
            atomSource.Play(cueName);
        }
        else if (sTAGE_TYPE ==STAGE_TYPE.WILDNESS)
        {
            cueName = "footstep_dirt-001";
            atomSource.Play(cueName);
        }
       
    }

    public void PlayPlayerSE(string cueName)
    {
        atomSource.Play(cueName);
    }
}
