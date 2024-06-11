using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;

public class BGMManager : MonoBehaviour
{
    

    [SerializeField] CriAtomSource bGMAtomSource;
    [SerializeField] string  bGMCueName;
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
            StartBGM(bGMCueName);
        }
        
    }

  

    public void StartBGM(string cueName)
    {
        bGMAtomSource.Play(cueName);
    }

    public void StopBGM()
    {
        Debug.Log("STOPBGM");
        bGMAtomSource.Stop();
    }
}
