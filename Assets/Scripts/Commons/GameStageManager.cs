using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStageManager : MonoBehaviour
{

    string nextStageName = "";

    public static GameStageManager Instance { get; private set; }
    void Awake()
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

    public void SetNextStageName(string nextStage)
    {
        nextStageName = nextStage;
    }

    public string GetNextStageName()
    {
        return nextStageName;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Time.timeScale = 4.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }
} 