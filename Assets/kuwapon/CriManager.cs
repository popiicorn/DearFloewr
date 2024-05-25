using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;

public class CriManager : MonoBehaviour
{
    public static CriManager instance;
    private void Awake()
    { 
        instance = this;
    }
   
       
       
    

    [SerializeField] CriAtomSource playerAtomSource;
    [SerializeField] CriAtomSource stageSEatomSource;
    [SerializeField] CriAtomSource bGIAtomSource;
    [SerializeField] PLAYER_TYPE pLAYER_TYPE;
    [SerializeField] bool bgi;
    public enum PLAYER_TYPE
    {
        GIRL,
        ROBOT,
        NULL,

    }

    bool push = false;

    private void Start()
    {
        if (bgi==true)
        {
            StartBGI(0);
        }
        else
        {

        }
    }

    public void PlayPlayerSE(string  cueName)
    {
        playerAtomSource.Play(cueName);
    }

    public void PlayPushSE()
    {
        if (push == false)
        {
            push = true;
            if (pLAYER_TYPE==PLAYER_TYPE.ROBOT)
            {
                PlayPlayerSE("blockMove_rovo");
            }
            else if (pLAYER_TYPE == PLAYER_TYPE.GIRL)
            {
                PlayPlayerSE("blockMove_girl");
            }
            else
            {

            }
            
        }

        //if (push==false)
        // {
        //     StartCoroutine(loopSE());
        // }
        // else { return; }
    }

    /*IEnumerator loopSE()
    {
        push = true;
        yield return null;
        PlayPlayerSE("blockMove");
        yield return new WaitForSeconds(1.6f);
        push = false;


    }*/
    public void StopSE()
    {
        push = false;
        playerAtomSource.Stop();
    }

    public void StartBGI(int cueNum)
    {
        bGIAtomSource.Play(cueNum);
    }
    
    public void StopBGI()
    {
        bGIAtomSource.Stop();
    }

    public void PlayObjSE(string cueName)
    {
        stageSEatomSource.Play(cueName);
    }
    public void StopObjSE()
    {
        stageSEatomSource.Stop();
    }

}
