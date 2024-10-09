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

    public bool CheckGetBonus()
    {
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        // �Ō�̐������擾
        string last = sceneName.Substring(sceneName.Length - 2, 2);
        int stageNum = int.Parse(last) - 1;
        return saveData.stages[stageNum].getBonus;
    }

    public void SetBonus()
    {
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        // �Ō�̐������擾
        string last = sceneName.Substring(sceneName.Length - 2, 2);
        int stageNum = int.Parse(last) - 1;

        saveData.stages[stageNum].getBonus = true;

        Save();
        // �S�Ă�Bonus���擾���Ă��邩�ǂ����𔻒�
        if(IsAllBonusGet())
        {
            SteamAchievementManager.Instance.UnlockAchievement("ACHIEVEMENT_12");
            saveData.stages[34].isOpened = true;
        }
    }
    public void SetCleared(int stageNumber)
    {
        saveData.stages[stageNumber].isCleared = true;
        int nextStage = stageNumber + 1;
        if (nextStage < saveData.stages.Length-1)
        {
            saveData.stages[nextStage].isOpened = true;
        }
        if ((nextStage == 34) && IsAllBonusGet())
        {
            saveData.stages[34].isOpened = true;
        }
        Save();
    }

    public void SetMovieStage(int num, bool isMovieStage)
    {
        saveData.stages[num].isMovieStage = isMovieStage;
        Save();
    }

    // stageNumber34���̂����đS�Ă�Bonus���擾���Ă��邩�ǂ����𔻒肷��
    public bool IsAllBonusGet()
    {
        for (int i = 0; i < saveData.stages.Length - 1; i++)
        {
            if(i == 34)
            {
                continue;
            }
            if (saveData.stages[i].isMovieStage)
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

    public void Save()
    {

        string saveDataJson = JsonUtility.ToJson(saveData, true);
        ES3.Save<string>(SAVE_KEY, saveDataJson);
        // PlayerPrefs.SetString(SAVE_KEY, saveDataJson);
    }

    void Load()
    {
        // PlayerPrefs�̃R�[�h��ES3�ɕύX
        if (ES3.KeyExists(SAVE_KEY))
        {
            string saveDataJson = ES3.Load<string>(SAVE_KEY);
            saveData = JsonUtility.FromJson<SaveData>(saveDataJson);
        }
        else
        {
            saveData = new SaveData();
        }
    }
    // ?��\�������񐔂��L�^
    public void AddQuestionCount()
    {
        saveData.questionCount++;
        Save();
        if(saveData.questionCount == 100)
        {
            SteamAchievementManager.Instance.UnlockAchievement("ACHIEVEMENT_14");
        }
    }

    public float GetWalkDistance()
    {
        return saveData.walkDistance;
    }

    public void SetWalkDistance(float distance)
    {
        saveData.walkDistance = distance;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.A))
        {
            // �S�X�e�[�W���J��
            for (int i = 0; i < saveData.stages.Length-1; i++)
            {
                saveData.stages[i].isOpened = true;
            }
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.F))
        {
            // �S�X�e�[�W���J��
            for (int i = 0; i < saveData.stages.Length - 1; i++)
            {
                saveData.stages[i].getBonus = true;
            }
            if (IsAllBonusGet())
            {
                SteamAchievementManager.Instance.UnlockAchievement("ACHIEVEMENT_12");
                saveData.stages[34].isOpened = true;
            }
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.R))
        {
            // �S�X�e�[�W���J��
            for (int i = 0; i < saveData.stages.Length; i++)
            {
                saveData.stages[i].isOpened = false;
                saveData.stages[i].getBonus = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            saveData.stages[32].isCleared = false;
            saveData.stages[32].getBonus = false;
            saveData.stages[33].isCleared = false;
            saveData.stages[34].isOpened = false;
            Save();
        }
    }

    [System.Serializable]
    public class SaveData
    {
        public Stage[] stages = new Stage[35];
        // �H��\��������
        public int questionCount;
        // �������������L�^
        public float walkDistance;

        public SaveData()
        {
            for (int i = 0; i < stages.Length; i++)
            {
                stages[i] = new Stage(i);
            }
            stages[0].isOpened = true;
        }
        // ������
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
