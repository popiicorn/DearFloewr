using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;

public class AisacManager : MonoBehaviour
{
    [SerializeField] CriAtomSource atomSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAisac()
    {

        atomSource.SetAisacControl("Filter", 0.6f);
    }

    public void OffAisac()
    {

        atomSource.SetAisacControl("Filter", 0);
    }


}

