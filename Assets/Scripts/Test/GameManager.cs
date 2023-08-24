using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float fadeTime = 1f;
    [SerializeField] string nextSceneName;
    public static GameManager Instance { get; private set; }
    public bool IsGameClear;
    public bool IsPreGameClear;
    private void Awake()
    {
        Instance = this;
    }
    public void GameClear()
    {
        if (IsGameClear)
        {
            return;
        }
        IsGameClear = true;
        StartCoroutine(ToNextScene(3));
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


    IEnumerator ToNextScene(int time)
    {
        yield return new WaitForSeconds(time);
        FadeManager.Instance.LoadScene(nextSceneName, fadeTime);
    }
}
