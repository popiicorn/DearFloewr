using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    enum TransitionName
    {
        None,
        Transition_1,
        Transition_2,
        Transition_3,
        Transition_4,
    }
    [SerializeField] TransitionName transitionName;
    [SerializeField] float fadeTime = 1f;
    [SerializeField] string nextSceneName;
    [SerializeField] float nextTime = 3;
    public static GameManager Instance { get; private set; }
    public bool IsGameClear;
    public bool IsPreGameClear;
    private void Awake()
    {
        Instance = this;
    }

    public void SetNextTime(float time)
    {
        nextTime = time;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.R))
        {
            string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            EventSaveDatas.Instance.SaveData(sceneName+"XX");
            EventSaveDatas.Instance.StopwatchStop();
            FadeManager.Instance.LoadScene("Stage_EV00", 1f);
        }
    }

    public void GameClear()
    {
        if (IsGameClear)
        {
            return;
        }
        IsGameClear = true;

        StartCoroutine(ToNextScene(nextTime));
    }
    public void PreGameClear()
    {
        if (IsPreGameClear)
        {
            return;
        }
        IsPreGameClear = true;
        StartCoroutine(ToNextScene(0));
    }


    IEnumerator ToNextScene(float time)
    {
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        if (EventSaveDatas.Instance)
        {
            EventSaveDatas.Instance.SaveData(sceneName);
            EventSaveDatas.Instance.StopwatchStop();
        }
        yield return new WaitForSeconds(time);
        FadeManager.Instance.LoadScene(GetNextSceneName(), fadeTime);
    }

    string GetNextSceneName()
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
            default:
                return "Title";
        }
    }

    public void GameOver()
    {
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        FadeManager.Instance.LoadScene(sceneName, fadeTime);
    }
}

