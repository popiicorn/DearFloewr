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
    [SerializeField] CriAtomSource uiAtomSource;
    [SerializeField] CriAtomSource pos3DAtomSource;
    [SerializeField] PLAYER_TYPE pLAYER_TYPE;
    [SerializeField] NoiseManager noiseManager;
    [SerializeField] MovieSoundManager movieSoundManager;
    [SerializeField] bool bgi;
    public bool stage11 = false;
    bool bGIISPause = false;
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
            StartCoroutine("DeleyBGI"); 
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

    public void Play3D()
    {
        pos3DAtomSource.Play();
    }
    public void Stop3D()
    {
       pos3DAtomSource.Stop();
    }

    public void PlayUISE(string cueName)
    {
        uiAtomSource?.Play(cueName);
    }

    IEnumerator DeleyBGI()
    {
        yield return new WaitForSeconds(0.1f);
        StartBGI(0);
    }

    /*public void OnPauseCRI()
    {
        CriAtomSource.Status status00 = bGIAtomSource.status;
        if (status00 == CriAtomSource.Status.Playing)
        {
            bGIAtomSource.Pause(true);
        }
        else { return; }

        CriAtomSource.Status status01 = stageSEatomSource.status;
        if (status01 == CriAtomSource.Status.Playing)
        {
            stageSEatomSource.Pause(true);
        }
        else { return; }

        CriAtomSource.Status status02 = playerAtomSource.status;
        if (status02 == CriAtomSource.Status.Playing)
        {
            playerAtomSource.Pause(true);
        }
        else { return; }

        CriAtomSource.Status status03 = uiAtomSource.status;
        if (status03 == CriAtomSource.Status.Playing)
        {
            uiAtomSource.Pause(true);
        }
        else { return; }*/

    public void OnPauseCRI()
    {
        CriAtomSource.Status status00 = bGIAtomSource.status;
        if (status00 == CriAtomSource.Status.Playing)
        {
            //bGIAtomSource.Pause(true);
            CriAtomEx.ApplyDspBusSnapshot("on", 1);
            bGIISPause = true;
        }
        

        if (noiseManager != null)
        {
            noiseManager.atomSource.Pause(true);
        }
        

        if (movieSoundManager != null)
        {
            movieSoundManager.MovieOnPause(); ;
        }

        if (pos3DAtomSource != null)
        {
            pos3DAtomSource.Pause(true); ;
        }



        stageSEatomSource.Pause(true);
        playerAtomSource.Pause(true);
        uiAtomSource.Pause(true);
        
        //movieSoundManager.MovieOnPause();

    }

    public void OffPauseCRI()
    {
        if (bGIISPause==true)
        {
            //bGIAtomSource.Pause(false);
            CriAtomEx.ApplyDspBusSnapshot("off", 1);
            bGIISPause = false;
        }
       

        if (noiseManager != null)
        {
            noiseManager.atomSource.Pause(false);
        }
        

        if (movieSoundManager != null)
        {
            movieSoundManager.MovieOffPause(); ;
        }
        
        if (pos3DAtomSource != null)
        {
            pos3DAtomSource.Pause(false); ;
        }

        stageSEatomSource.Pause(false);
        playerAtomSource.Pause(false);
        uiAtomSource.Pause(false);
        //pos3DAtomSource.Pause(false);
        //MovieSoundManager.instance.MovieOffPause();

    }

}
