using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;

public class hintoSEManager : MonoBehaviour
{
    public static hintoSEManager instance;
    [SerializeField] CriAtomSource hintoAtomSource;
    bool setSE = false;
    bool offSE = false;
    GS09_Rock GS09_Rock;

    private void Awake()
    {
        instance = this;
    }
    
    public void PlayHintoSE()
    {
        if (setSE==true)
        {
            hintoAtomSource.Play("hinto");
            setSE = false;
        }
        
    }

    public void StopHintoSE()
    {
        if (offSE==true)
        {
            hintoAtomSource.Stop();
            offSE = false;
        }
        
    }
    /*private void Update()
    {
        if (GS09_Rock.IsSet== true)
        {
            PlayHintoSE();
        }
        if (GS09_Rock.IsSet == false)
        {
            StopHintoSE();
        }
    }*/
}
