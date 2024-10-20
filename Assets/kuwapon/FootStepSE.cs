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
        ROBOT,
        FACTRY,
        NULL,
    
    }

    public void PlaysSE()
    {
        string cueName;
        if (sTAGE_TYPE==STAGE_TYPE.FACTRY)
        {
            cueName = "footStep_floor";
            atomSource.Play(cueName);
        }
        else if (sTAGE_TYPE ==STAGE_TYPE.WILDNESS)
        {
            cueName = "footstep_dirt";
            atomSource?.Play(cueName);
        }
        else if (sTAGE_TYPE == STAGE_TYPE.ROBOT)
        {
            cueName = "footstep_dirt_robo";
            atomSource.Play(cueName);
        }
        else
        {

        }
       
    }

    public void PlayPlayerSE(string cueName)
    {
        atomSource.Play(cueName);
    }

}
