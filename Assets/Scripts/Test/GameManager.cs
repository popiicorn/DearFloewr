using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
        EventSaveDatas.Instance.SaveData(sceneName);
        EventSaveDatas.Instance.StopwatchStop();
        yield return new WaitForSeconds(time);
        FadeManager.Instance.LoadScene(nextSceneName, fadeTime);
    }
}
