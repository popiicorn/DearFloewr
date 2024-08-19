using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{

    const string SAVE_KEY = "DEAR_FLOWER";
    public static SaveManager Instance { get; private set; }
    public SaveData saveData;
    private void Awake()
    {
        saveData = new SaveData();

        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetBonus(int stageNumber)
    {
        saveData.stages[stageNumber].getBonus = true;
    }
    public void SetCleared(int stageNumber)
    {
        saveData.stages[stageNumber].isCleared = true;
        if (stageNumber + 1 < saveData.stages.Length)
        {
            saveData.stages[stageNumber + 1].isOpened = true;
        }
    }
    public void SetMovieStage(int stageNumber)
    {
        saveData.stages[stageNumber].isMovieStage = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Save");
            Save();
        }
    }

    public void Save()
    {

        string saveDataJson = JsonUtility.ToJson(saveData, true);
        // PlayerPrefs.SetString(SAVE_KEY, saveDataJson);
        Debug.Log(saveDataJson);
    }

    [System.Serializable]
    public class SaveData
    {
        public Stage[] stages = new Stage[35];

        public SaveData()
        {
            for (int i = 0; i < stages.Length; i++)
            {
                stages[i] = new Stage(i);
            }
            stages[0].isOpened = true;
            stages[0].isCleared = true;
            stages[0].getBonus = true;
            stages[0].isMovieStage = true;
            stages[1].isOpened = true;
            stages[1].isCleared = true;
            stages[1].getBonus = false;
            stages[2].isOpened = true;

        }
        // ‰Šú‰»
    }

    [System.Serializable]
    public class Stage
    {
        public int stageNumber;
        public bool isOpened;
        public bool isCleared;
        public bool isMovieStage;
        public bool getBonus;

        public Stage(int number)
        {
            stageNumber = number;
            isOpened = false;
            isCleared = false;
            isMovieStage = false;
            getBonus = false;            
        }
    }
}
