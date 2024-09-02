using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;
using DG.Tweening;

public class BGMManager : MonoBehaviour
{
    

    [SerializeField] CriAtomSource bGMAtomSource;
    public string  bGMCueName;
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
            Debug.Log("StartBGM");
            StartBGM(bGMCueName);
        }
        
    }

  

    public void StartBGM(string cueName)
    {
        bGMAtomSource.Play(cueName);
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

    public void OffAisac()
    {
        DOVirtual.Float(0.7f, 0f, 3f, value =>
        {
            bGMAtomSource.SetAisacControl("Filter", value);
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


}
