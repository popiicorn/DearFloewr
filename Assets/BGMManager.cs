using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;
using DG.Tweening;

public class BGMManager : MonoBehaviour
{
    

    public CriAtomSource bGMAtomSource;
    public string  bGMCueName;
    public bool Stage33 = false; 
    CriAtomExPlayback bGMAtomPlayback = new CriAtomExPlayback(CriAtomExPlayback.invalidId);
    int blockIndex;
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
        bGMAtomPlayback = bGMAtomSource.Play(bGMCueName);
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

    public void BossBlockMove01()
    {
        blockIndex = bGMAtomPlayback.GetCurrentBlockIndex();
        if (blockIndex == 4)
        {
            bGMAtomPlayback.SetNextBlockIndex(6);
            Debug.Log("インタラクティブ4");
        }
        else if  (blockIndex == 6)
        {
            Debug.Log("インタラクティブ6");
            return;
        }
        else 
        {
            Debug.Log("インタラクティブ");
            bGMAtomPlayback.SetNextBlockIndex(5);
        }
    }

    public void BossBlockMove02()
    {
        bGMAtomPlayback.SetNextBlockIndex(7);
    }

}
