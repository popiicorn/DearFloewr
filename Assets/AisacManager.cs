using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;

public class AisacManager : MonoBehaviour
{
    [SerializeField] CriAtomSource atomSource;
    public static AisacManager instance;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update


    public void OnAisac()
    {

        atomSource.SetAisacControl("Filter", 0.6f);
    }

    public void OffAisac()
    {

        atomSource.SetAisacControl("Filter", 0);
    }

    public void OnBGMAisac(string aisacName)
    {
        atomSource.SetAisacControl(aisacName, 1f);
    }

    public void OffBGMAisac(string aisacName)
    {
        atomSource.SetAisacControl(aisacName, 0);
    }

}

