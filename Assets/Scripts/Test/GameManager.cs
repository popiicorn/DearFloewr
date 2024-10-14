using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using Com.LuisPedroFonseca.ProCamera2D.TopDownShooter;

public class GameManager : MonoBehaviour
{
    public enum TransitionName
    {
        None,
        Transition_1,
        Transition_2,
        Transition_3,
        Transition_4,
        Ending,
        Title,
        LastStage,
        LastMove,
        Selection,
    }
    [SerializeField] TransitionName transitionName;
    [SerializeField] DOTweenAnimation fadeObj;
    [SerializeField] DOTweenAnimation fadeOutObj;
    [SerializeField] string nextStageName;
    [SerializeField] GameObject optionPanel;
    [SerializeField] OptionParam optionParam;
    public bool IsOptionPanelActive { get => optionPanel.activeSelf; }

    public static GameManager Instance { get; private set; }
    public bool IsGameClear;
    public bool IsGameOver;
    public bool IsCamMoveCleared;
    public bool IsPreGameClear;
    string nextSceneName = "Transition_1";
    string currentSceneName;
    public UnityAction OnClearCkeckSteamAchievement;
    const string StageSelectName = "Title_StageSelect";

    private void Awake()
    {
        IsGameOver = false;
        IsGameClear = false;
        IsCamMoveCleared = false;
        IsPreGameClear = false;
        Instance = this;
    }

    private void Start()
    {
        currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }
    // currentSceneNameにTransitionがふくまれているかどうかを判定する
    bool IsTransitionScene()
    {
        return currentSceneName.Contains("Transition");
    }


    public void SetTrandition(TransitionName name)
    {
        transitionName = name;
    }

    public void NextStage()
    {
        if (IsGameOver)
        {
            return;
        }
        if (IsGameClear)
        {
            return;
        }
        IsGameClear = true;
        nextSceneName = GameStageManager.Instance.GetNextStageName();
        ToNextScene();
    }

    public void GameClear()
    {
        if (IsGameOver)
        {
            return;
        }

        if (IsGameClear)
        {
            return;
        }
        OnClearCkeckSteamAchievement?.Invoke();
        Debug.Log("GameClear");
        if (transitionName == TransitionName.Ending || transitionName == TransitionName.Title)
        {

        }
        else if (nextStageName == "")
        {
            // 現在のシーン名を取得して、最後の数字をインクリメントして次のシーン名を取得する
            string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            // 最後の数字を取得
            string last = sceneName.Substring(sceneName.Length - 2, 2);
            int stageNum = int.Parse(last);
            stageNum++;
            nextStageName = "Stage_" + stageNum.ToString("D2");
        }
        GameStageManager.Instance.SetNextStageName(nextStageName);
        IsGameClear = true;
        nextSceneName = GetNextTransitionSceneName();
        ToNextScene();
        Save();
    }

    void Save()
    {
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        // 最後の数字を取得
        string last = sceneName.Substring(sceneName.Length - 2, 2);
        int stageNum = int.Parse(last)-1;
        SaveManager.Instance.SetCleared(stageNum);
    }

    public void PreGameClear()
    {
        if (IsPreGameClear)
        {
            return;
        }
        IsPreGameClear = true;
        nextSceneName = GetNextTransitionSceneName();
        ToNextScene();
    }

    public void GameOver()
    {
        if (IsGameClear)
        {
            return;
        }
        Debug.Log("GameOver");
        IsGameOver = true;
        nextSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        ToNextScene();
    }


    void ToNextScene()
    {        
        fadeObj.gameObject.SetActive(true);
        Debug.Log("ToNextScene");
    }

    string GetNextTransitionSceneName()
    {
        switch (transitionName)
        {
            case TransitionName.Transition_1:
                return "Transition_1";
            case TransitionName.Transition_2:
                return "Transition_2";
            case TransitionName.Transition_3:
                return "Transition_3";
            case TransitionName.Transition_4:
                return "Transition_4";
            case TransitionName.Ending:
                return "End_Demo";
            case TransitionName.LastStage:
                return "Stage_36";
            case TransitionName.LastMove:
                return "Stage_37";
            case TransitionName.Selection:
                return "Title_StageSelect";
            case TransitionName.Title:
            default:
                return "Title";
                // return "Title_Demo";
        }
    }

    public void Transition()
    {
        Debug.Log("Transition");
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
    }

    public void StageSelect(int stageNumber, TransitionName transitionName)
    {
        GameStageManager.Instance.SetNextStageName($"Stage_{stageNumber.ToString("D2")}");
        SetTrandition(transitionName);
        nextSceneName = GetNextTransitionSceneName();
        ToNextScene();
    }

    public void ToTitle()
    {
        Debug.Log("ToTitle");
        if (fadeObj.animationType == DOTweenAnimation.AnimationType.Color)
        {
            fadeObj.delay = optionParam.delayColor;
            fadeObj.duration = optionParam.durationColor;
        }
        else
        {
            fadeObj.delay = optionParam.delay;
            fadeObj.duration = optionParam.duration;
        }

        if(fadeOutObj.animationType == DOTweenAnimation.AnimationType.Fade)
        {
            fadeOutObj.delay = optionParam.delayColor;
            fadeOutObj.duration = optionParam.durationColor;
        }
        else
        {
            fadeOutObj.delay = optionParam.delay;
            fadeOutObj.duration = optionParam.duration;
        }

        nextSceneName = "Title";
        ToNextScene();
    }

    public void ToStageSelect()
    {
        Debug.Log("ToStageSelect");
        CriManager.instance.PlayUISE("TorTittle");
        if (fadeObj.animationType == DOTweenAnimation.AnimationType.Color)
        {
            fadeObj.delay = optionParam.delayColor;
            fadeObj.duration = optionParam.durationColor;
        }
        else
        {
            fadeObj.delay = optionParam.delay;
            fadeObj.duration = optionParam.duration;
        }

        if (fadeOutObj.animationType == DOTweenAnimation.AnimationType.Fade)
        {
            fadeOutObj.delay = optionParam.delayColor;
            fadeOutObj.duration = optionParam.durationColor;
        }
        else
        {
            fadeOutObj.delay = optionParam.delay;
            fadeOutObj.duration = optionParam.duration;
        }

        nextSceneName = "Title_StageSelect";
        ToNextScene();
    }


    private void Update()
    {
        if (IsTransitionScene())
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentSceneName == StageSelectName)
            {
                return;
            }
            optionPanel.SetActive(true);
            CriManager.instance.OnPauseCRI();
        }
    }

    public void OnHomeButton()
    {
        // タイトルへ戻る
        if (IsGameClear)
        {
            return;
        }
        ToTitle();
    }



    public void OnBackButton()
    {
        CriManager.instance.OffPauseCRI();
        optionPanel.SetActive(false);
        SaveManager.Instance.Save();
        //MovieSoundManager.instance.MovieOffPause();
    }

    [System.Serializable]
    class OptionParam
    {
        public float durationColor;
        public float delayColor;
        [Space]
        public float duration;
        public float delay;
    }
}

