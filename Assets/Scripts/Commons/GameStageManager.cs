using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStageManager : MonoBehaviour
{
    int stageIndex = 0;
    const int stageCount = 7;

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

    public string GetNextStageName()
    {
        stageIndex++;
        Debug.Log("stageIndex: " + stageIndex);
        if (stageCount < stageIndex)
        {
            stageIndex = 0;
            return "Title_Demo";
        }
        return "Stage_" + stageIndex.ToString("D2");
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Time.timeScale = 4.0f;
        }
    }
} 