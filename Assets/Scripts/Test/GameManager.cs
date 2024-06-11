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
        Debug.Log("NextStage");
        if (IsGameClear)
        {
            return;
        }
        Debug.Log("NextStage2");
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

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.R))
        {
            string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            EventSaveDatas.Instance.SaveData(sceneName + "XX");
            EventSaveDatas.Instance.StopwatchStop();
            FadeManager.Instance.LoadScene("Stage_EV00", 1f);
        }
    }
}

