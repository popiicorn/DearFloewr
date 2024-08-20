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
            Load();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetBonus()
    {
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        // ÅŒã‚Ì”š‚ğæ“¾
        string last = sceneName.Substring(sceneName.Length - 2, 2);
        int stageNum = int.Parse(last) - 1;

        saveData.stages[stageNum].getBonus = true;
    }
    public void SetCleared(int stageNumber)
    {
        saveData.stages[stageNumber].isCleared = true;
        if (stageNumber + 1 < saveData.stages.Length)
        {
            saveData.stages[stageNumber + 1].isOpened = true;
            if ((stageNumber + 1 == 34) && IsAllBonusGet())
            {
                saveData.stages[34].isOpened = true;
            }
        }
        Save();
    }

    // stageNumber34‚ğ‚Ì‚¼‚¢‚Ä‘S‚Ä‚ÌBonus‚ğæ“¾‚µ‚Ä‚¢‚é‚©‚Ç‚¤‚©‚ğ”»’è‚·‚é
    public bool IsAllBonusGet()
    {
        for (int i = 0; i < saveData.stages.Length - 1; i++)
        {
            if(i == 34)
            {
                continue;
            }
            if (!saveData.stages[i].getBonus)
            {
                return false;
            }
        }
        return true;
    }

    public void SetMovieStage(int stageNumber)
    {
        saveData.stages[stageNumber].isMovieStage = true;
    }

    void Save()
    {

        string saveDataJson = JsonUtility.ToJson(saveData, true);
        PlayerPrefs.SetString(SAVE_KEY, saveDataJson);
        Debug.Log(saveDataJson);
    }

    void Load()
    {
        if (PlayerPrefs.HasKey(SAVE_KEY))
        {
            string saveDataJson = PlayerPrefs.GetString(SAVE_KEY);
            Debug.Log(saveDataJson);
            saveData = JsonUtility.FromJson<SaveData>(saveDataJson);
        }
        else
        {
            saveData = new SaveData();
        }
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
