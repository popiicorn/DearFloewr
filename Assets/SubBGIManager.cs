using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;

public class SubBGIManager : MonoBehaviour
{
    public static SubBGIManager instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] CriAtomSource bGIAtomSource;
    [SerializeField] string bGIName;


    // Start is called before the first frame update
    void Start()
    {
        StartSubBGI();
    }

    public void StartSubBGI()
    {
        bGIAtomSource.Play(bGIName);
    }

    public void StopBGI()
    {
        bGIAtomSource.Stop();
    }
}
