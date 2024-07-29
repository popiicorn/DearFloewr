using System.Collections;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    enum TransitionName
    {
        None,
        Transition_1,
        Transition_2,
        Transition_3,
        Transition_4,
        Ending,
        Title,
    }
    [SerializeField] TransitionName transitionName;
    [SerializeField] DOTweenAnimation fadeObj;
    [SerializeField] string nextStageName;
    public static GameManager Instance { get; private set; }
    public bool IsGameClear;
    public bool IsCamMoveCleared;
    public bool IsPreGameClear;
    string nextSceneName = "Transition_1";
    private void Awake()
    {
        Instance = this;
    }

    public void NextStage()
    {
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
        if (IsGameClear)
        {
            return;
        }
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
        Debug.Log("GameOver");
        nextSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        ToNextScene();
    }


    void ToNextScene()
    {
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        if (EventSaveDatas.Instance)
        {
            EventSaveDatas.Instance.SaveData(sceneName);
            EventSaveDatas.Instance.StopwatchStop();
        }
        Debug.Log("ToNextScene");
        fadeObj.gameObject.SetActive(true);
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
            case TransitionName.Title:
            default:
                return "Title_Demo";
        }
    }

    public void Transition()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
    }
}

