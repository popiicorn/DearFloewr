using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;

public class MovieSoundManager : MonoBehaviour
{
    public static MovieSoundManager instance;
    private void Awake()
    {
        instance = this;
    }

    [SerializeField] CriAtomSource movieAtomSource;
    bool movieISPause = false;

    public void MovieOnPause()
    {
        
        if (movieISPause == false)
        {
            //movieAtomSource.Pause(true);
            movieISPause = true;
            ChangeSnapshotOn();
        }
        else { return; }
    }

    public void MovieOffPause()
    {
        if (movieISPause==true)
        {
            movieISPause = false;
            ChangeSnapshotOff();
        }
        else { return; }
    }

    void ChangeSnapshotOn()
    {
        CriAtomEx.ApplyDspBusSnapshot("on", 1);
        Debug.Log("スナップショットON");
    }
    void ChangeSnapshotOff()
    {
        CriAtomEx.ApplyDspBusSnapshot("off", 1);
        Debug.Log("スナップショットOFF");
    }
}

