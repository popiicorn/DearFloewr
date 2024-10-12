using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;
using DG.Tweening;

public class BGMManager : MonoBehaviour
{
    

    public CriAtomSource bGMAtomSource;
    public string  bGMCueName;
    CriAtomExPlayback bGMAtomPlayback = new CriAtomExPlayback(CriAtomExPlayback.invalidId);
    public static BGMManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        if (bGMCueName != null)
        {
           StartBGM();
        }
        
    }

  

    public void StartBGM()
    {
        CriAtomSource.Status status = bGMAtomSource.status;
        if (status == CriAtomSource.Status.Playing)
        {
            return;

        }
        Debug.Log("StartBGM");
        bGMAtomSource.Play(bGMCueName);
    }

    public void StopBGM()
    {
        
        bGMAtomSource.Stop();
    }
    public void OnAisac()
    {
        DOVirtual.Float(0f, 0.7f, 5f, value =>
        {
            bGMAtomSource.SetAisacControl("Filter", value);
        });

        
    }

    public void OnFade()
    {
        DOVirtual.Float(0f, 0.8f, 0.5f, value =>
        {
            bGMAtomSource.SetAisacControl("Fade", value);
        });


    }

    public void OffAisac()
    {
        DOVirtual.Float(0.7f, 0f, 3f, value =>
        {
            bGMAtomSource.SetAisacControl("Filter", value);
        });
        
    }
    public void OffFade()
    {
        DOVirtual.Float(0.8f, 0f, 0.5f, value =>
        {
            bGMAtomSource.SetAisacControl("Fade", value);
        });

    }

    public void OnBGMAisac(string aisacName)
    {
        DOVirtual.Float(0f, 1f, 1f, value =>
        {
            bGMAtomSource.SetAisacControl(aisacName, value);
        });


    }

    public void OffBGMAisac(string aisacName)
    {
        DOVirtual.Float(1f, 0f, 1f, value =>
        {
            bGMAtomSource.SetAisacControl(aisacName, value);
        });

    }

    public void PauseBGM()
    {
        CriAtomSource.Status status = bGMAtomSource.status;
        if (status== CriAtomSource.Status.Playing)
        {
            bGMAtomSource.Pause(true);
        }
        

    }

    public void DestroyBGM()
    {
        Destroy(this.gameObject);
    }

    public void BlockMove(int id)
    {
        if (bGMAtomPlayback.id != CriAtomExPlayback.invalidId)
        {
            if (bGMAtomPlayback.GetCurrentBlockIndex() != id)
            {
                bGMAtomPlayback.SetNextBlockIndex(id);
            }
        }
    }

}
