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


    [SerializeField] CriAtomSource atomSource;
    bool push = false;

    public void PlaySE(int cueNum)
    {
        atomSource.Play(cueNum);
    }

    public void PlayPushSE()
    {
        if (push==false)
        {
            StartCoroutine(loopSE());
        }
        else { return; }
    }

    IEnumerator loopSE()
    {
        push = true;
        yield return null;
        PlaySE(0);
        yield return new WaitForSeconds(1.6f);
        push = false;


    }
    public void StopSE()
    {
        atomSource.Stop();
    }



}
