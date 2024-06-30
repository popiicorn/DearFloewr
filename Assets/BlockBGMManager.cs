using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;

public class BlockBGMManager : MonoBehaviour
{
    [SerializeField] CriAtomSource bGMAtomSource;
    public string bGMCueName;
    CriAtomExPlayback bGMAtomPlayback = new CriAtomExPlayback(CriAtomExPlayback.invalidId);

   
    void Start()
    {
        Invoke("StartBGM", 0.3f);
    }

    
    public void StartBGM()
    {
        if (bGMCueName != null)
        {
            bGMAtomPlayback = bGMAtomSource.Play(bGMCueName);
        }
    }

    public void StopBGM()
    {

        bGMAtomSource.Stop();
    }

    public void BlockMove(int id)
    {
        if (bGMAtomPlayback.id!=CriAtomExPlayback.invalidId)
        {
            if (bGMAtomPlayback.GetCurrentBlockIndex()!=id)
            {
                bGMAtomPlayback.SetNextBlockIndex(id);
            }
        }
    }


}
