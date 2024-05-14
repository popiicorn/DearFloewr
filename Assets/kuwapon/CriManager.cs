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
    [SerializeField] CriAtomSource demoStage01atomSource;
    [SerializeField] CriAtomSource bGIAtomSource;
    bool push = false;

    private void Start()
    {
        StartBGI(0);
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
            PlayPlayerSE("blockMove");
        }

        //if (push==false)
        // {
        //     StartCoroutine(loopSE());
        // }
        // else { return; }
    }

    IEnumerator loopSE()
    {
        push = true;
        yield return null;
        PlayPlayerSE("blockMove");
        yield return new WaitForSeconds(1.6f);
        push = false;


    }
    public void StopSE()
    {
        push = false;
        playerAtomSource?.Stop();
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
        demoStage01atomSource.Play(cueName);
    }
    public void StopObjSE()
    {
        demoStage01atomSource.Stop();
    }

}
